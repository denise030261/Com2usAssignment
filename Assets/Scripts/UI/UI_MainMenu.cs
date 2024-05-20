using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    [SerializeField]
    Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OnClickStartGame);
        exitButton.onClick.AddListener(OnClickExitGame);
    }

    void OnClickStartGame()
    {
        SceneManager.LoadScene("Stage1");
    }


    void OnClickExitGame()
    {
        Application.Quit();
    }
}
