using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountItem : MonoBehaviour
{
    GameObject item;

    private void OnEnable()
    {
        if(gameObject.activeSelf)
            Invoke("Count", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BigMoney" || collision.gameObject.tag == "MediumMoney"
            || collision.gameObject.tag == "SmallMoney")
        {
            item = collision.gameObject;
            item.transform.SetParent(gameObject.transform);
        }
    }

    void Count()
    {
        foreach(Transform child in this.transform)
        {
            if (child.gameObject.tag== "BigMoney")
            {
                GameManager.Instance.bigMoneyNum++;
            }
            else if(child.gameObject.tag == "MediumMoney")
            {
                GameManager.Instance.mediumMoneyNum++;
            }
            else if(child.gameObject.tag== "SmallMoney")
            {
                GameManager.Instance.smallMoneyNum++;
            }
        }

        GameManager.Instance.CaculateMonoey();
    }
}
