using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    [SerializeField]
    Text targetMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        targetMoneyText.text = GameManager.instance.targetMoney.ToString();
    }
}
