using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera playerOneCamera;
    [SerializeField] private Camera playerTwoCamera;

    void Start()
    {
        playerOneCamera.enabled = true;
        playerTwoCamera.enabled = false;
    }

    public void SwitchCamera()
    {
        playerOneCamera.enabled = !playerOneCamera.enabled;
        playerTwoCamera.enabled = !playerTwoCamera.enabled;
    }
}
