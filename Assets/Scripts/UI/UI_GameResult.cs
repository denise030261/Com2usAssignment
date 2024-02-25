using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameResult : MonoBehaviour
{
    [SerializeField]
    GameObject gameresultDieJud;

    [SerializeField]
    Text gameresultDieText;

    [SerializeField]
    GameObject gameresultNotDieJud;

    [SerializeField]
    Text gameresultNotDieText;

    [SerializeField]
    GameObject gameresultCal;

    [SerializeField]
    Button backButton;

    [SerializeField]
    Text bigMoneyText;

    [SerializeField]
    Text bigMoneySumText;

    [SerializeField]
    Text mediumMoneyText;

    [SerializeField]
    Text mediumMoneySumText;

    [SerializeField]
    Text smallMoneyText;

    [SerializeField]
    Text smallMoneySumText;

    [SerializeField]
    Text totalMoneyText;

    [SerializeField]
    float judgementTime;

    [SerializeField]
    float calculateTime;

    private void OnEnable()
    {
        if(gameObject.activeSelf)
        {
            Init();

            if (!GameManager.instance.isMissing && !GameManager.instance.isDie)
            {
                gameresultDieJud.SetActive(false);
                gameresultNotDieJud.SetActive(true);
                gameresultNotDieText.text = "";
            }
            else
            {
                gameresultDieJud.SetActive(true);
                gameresultNotDieJud.SetActive(false);
                gameresultDieText.text = "";
            }
            Invoke("ShowJudgement", judgementTime);
        }
    }

    void ShowJudgement()
    {
        if (GameManager.instance.isDie)
        {
            Debug.Log("»ç¸Á");
            gameresultDieText.text = "»ç¸Á";
        }
        else if(GameManager.instance.isMissing)
        {
            Debug.Log("½ÇÁ¾");
            gameresultDieText.text = "½ÇÁ¾";
        }

        if(GameManager.instance.isSuccess)
        {
            Debug.Log("½ÂÁø");
            gameresultNotDieText.color = new Color(0, 0, 1);
            gameresultNotDieText.text = "½ÂÁø";
        }
        else if(!GameManager.instance.isSuccess)
        {
            Debug.Log("ÇØ°í");
            gameresultNotDieText.color = new Color(1, 0, 0);
            gameresultNotDieText.text = "ÇØ°í";
        }

        Invoke("ShowCalculate", calculateTime);
    }

    void ShowCalculate()
    {
        backButton.enabled = true;
        gameresultCal.SetActive(true);
        SetText();
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Init()
    {
        gameresultCal.SetActive(false);
        gameresultNotDieJud.SetActive(false);
        gameresultDieJud.SetActive(false);

        backButton.onClick.AddListener(LoadMainMenu);
        backButton.enabled = false;
    }

    void SetText()
    {
        bigMoneyText.text = GameManager.instance.bigMoneyNum.ToString();
        mediumMoneyText.text = GameManager.instance.mediumMoneyNum.ToString();
        smallMoneyText.text = GameManager.instance.smallMoneyNum.ToString();

        bigMoneySumText.text = GameManager.instance.totalBigMoney.ToString();
        mediumMoneySumText.text = GameManager.instance.totalMediumMoney.ToString();
        smallMoneySumText.text = GameManager.instance.totalSmallMoney.ToString();

        totalMoneyText.text = GameManager.instance.totalMoney.ToString();
    }
}
