using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField]
    Vector2 transformItem;

    Rigidbody2D rb2;
    bool isGound;
    bool contanctItem;
    bool haveItem;
    GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        rb2 = GetComponent<Rigidbody2D>();
        contanctItem = false;
        haveItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (contanctItem && !haveItem)
            {
                item.transform.SetParent(gameObject.transform);
                item.transform.localPosition = transformItem;
                haveItem = true;
            }

            if (haveItem && isGound && !contanctItem)
            {
                item = transform.GetChild(0).gameObject;
                item.transform.SetParent(null);
                haveItem = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BigMoney" || collision.gameObject.tag == "MediumMoney"
            || collision.gameObject.tag == "SmallMoney")
        {
            item = collision.gameObject;
            contanctItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BigMoney" || collision.gameObject.tag == "MediumMoney"
            || collision.gameObject.tag == "SmallMoney")
        {
            contanctItem = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGound = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGound = false;
        }
    }
}
