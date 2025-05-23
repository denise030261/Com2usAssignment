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

            if (!GameManager.Instance.isMissing && !GameManager.Instance.isDie)
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
        if (GameManager.Instance.isDie)
        {
            Debug.Log("���");
            gameresultDieText.text = "���";
        }
        else if(GameManager.Instance.isMissing)
        {
            Debug.Log("����");
            gameresultDieText.text = "����";
        }

        if(GameManager.Instance.isSuccess)
        {
            Debug.Log("����");
            gameresultNotDieText.color = new Color(0, 0, 1);
            gameresultNotDieText.text = "����";
        }
        else if(!GameManager.Instance.isSuccess)
        {
            Debug.Log("�ذ�");
            gameresultNotDieText.color = new Color(1, 0, 0);
            gameresultNotDieText.text = "�ذ�";
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
        bigMoneyText.text = GameManager.Instance.bigMoneyNum.ToString();
        mediumMoneyText.text = GameManager.Instance.mediumMoneyNum.ToString();
        smallMoneyText.text = GameManager.Instance.smallMoneyNum.ToString();

        bigMoneySumText.text = GameManager.Instance.totalBigMoney.ToString();
        mediumMoneySumText.text = GameManager.Instance.totalMediumMoney.ToString();
        smallMoneySumText.text = GameManager.Instance.totalSmallMoney.ToString();

        totalMoneyText.text = GameManager.Instance.totalMoney.ToString();
    }
}
