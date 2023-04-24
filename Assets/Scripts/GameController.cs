using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject colliderContainer;
    [SerializeField] CameraController cameraController;
    [SerializeField] CoinDropper dropAction;
    [SerializeField] WinController winController;
    private InputActions mouseAction;
    private bool currPlayer;
    private int[] numTokens;
    

    void Start()
    {
        mouseAction = new InputActions();
        mouseAction.MouseClick.LMB.performed += OnMouseClick;
        mouseAction.Enable();
        currPlayer = false;
        numTokens = new int[7];

        //MenuController.connectNum gives the number needed to win
    }

    private void OnMouseClick(InputAction.CallbackContext obj)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            foreach (Transform child in colliderContainer.transform)
            {
                if (child.name == hit.collider.name)
                {
                    // if column != full - > drop the token in that collider's column
                    // else do nothing
                    int column = (hit.transform.name[hit.transform.name.Length - 1] - '0') - 1;
                    if (numTokens[column] < 6) {
                        dropAction.DropCoin(currPlayer, column);
                        cameraController.SwitchCamera();
                        currPlayer = !currPlayer;
                        // Check for win
                        winController.WinCheck(column, numTokens[column], currPlayer, MenuController.connectNum);
                    }
                    numTokens[column]++;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
