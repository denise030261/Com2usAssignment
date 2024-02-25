using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int CurrentHp;

    [SerializeField]
    int MaxHp;

    void Start()
    {
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHp<=0)
        {
            Destroy(gameObject);
        } // Die
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Gun")
        {
            CurrentHp--;
        } // Hurt
    }
}
