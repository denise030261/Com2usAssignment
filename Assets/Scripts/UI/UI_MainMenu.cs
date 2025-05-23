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

    [SerializeField]
    Button bgmButton;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("Menu");
        startButton.onClick.AddListener(OnClickStartGame);
        exitButton.onClick.AddListener(OnClickExitGame);
        bgmButton.onClick.AddListener(OnClickPlayBGM);
    }

    void OnClickStartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    void OnClickExitGame()
    {
        Application.Quit();
    }

    void OnClickPlayBGM()
    {
        Color color = bgmButton.GetComponent<Image>().color;
        if (bgmButton.GetComponent<Image>().color.a == 0.5)
        {
            color.a = 1;
            bgmButton.GetComponent<Image>().color = color;
            AudioManager.Instance.ContinueBGM();
        }
        else if(bgmButton.GetComponent<Image>().color.a ==1)
        {
            color.a = 0.5f;
            bgmButton.GetComponent<Image>().color = color;
            AudioManager.Instance.StopBGM();
        }
    }
}
