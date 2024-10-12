using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    int bigMoney;

    [SerializeField]
    int mediumMoney;

    [SerializeField]
    int smallMoney;

    public int targetMoney;

    public int bigMoneyNum;
    public int mediumMoneyNum;
    public int smallMoneyNum;

    public bool isDie;
    public bool isMissing;
    public bool isSuccess;

    public int totalMoney;
    public int totalBigMoney;
    public int totalMediumMoney;
    public int totalSmallMoney;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            if (instance != this) 
                Destroy(this.gameObject); 
        } //모노싱글톤 (중복방지를 위한)
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        bigMoneyNum = 0;
        mediumMoneyNum = 0;
        smallMoneyNum = 0;
        totalMoney = 0;
        isDie = false;
        isMissing = true;
        isSuccess = false;
    }

    public void CaculateMonoey()
    {
        totalBigMoney = bigMoney * bigMoneyNum;
        totalMediumMoney = mediumMoney * mediumMoneyNum;
        totalSmallMoney = smallMoney * smallMoneyNum;

        totalMoney = totalSmallMoney + totalMediumMoney + totalBigMoney;

        if(isDie || isMissing)
        {
            ZeroMoney();
        }

        if(totalMoney>=targetMoney)
        {
            isSuccess = true;
        }
        else
        {
            isSuccess = false;
        }
    }

    void ZeroMoney()
    {
        totalSmallMoney = 0;
        totalMediumMoney = 0;
        totalBigMoney = 0;
        bigMoneyNum = 0;
        mediumMoneyNum = 0;
        smallMoneyNum = 0;
        totalMoney = 0;
    }
}
