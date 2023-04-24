using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text valueText;
    private Dictionary<int, string> valueStringDict;
    static public int connectNum { get; private set; }  // pretty jank way to pass this value around, if you think of something better im down

    void Start()
    {
        valueStringDict = new Dictionary<int, string>()
        {
            {1, "One" },
            {2, "Two" },
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
        };
        connectNum = 2;
        slider.onValueChanged.AddListener(delegate { ValueChange(); });
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void ValueChange()
    {
        valueText.text = "Connect " + valueStringDict[(int)slider.value];
        connectNum = (int)slider.value;
    }

    void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }

    void StartGame()
    {
        SceneManager.LoadScene("Scene");
    }
}
