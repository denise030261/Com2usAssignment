using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    float waitDuration;

    [SerializeField]
    float turnDuration;

    Animator animator;
    BoxCollider2D bc2;
    SpriteRenderer spriteRenderer;
    int sliceNum;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Invoke("TurnLight", (waitDuration / turnDuration));
    }

    private void Init()
    {
        animator = GetComponent<Animator>();
        bc2 = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator.SetBool("isExplosion", false);
        bc2.enabled = false;
        sliceNum = 1;
    }

    void TurnLight()
    {   
        if(sliceNum == turnDuration)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255f);
            sliceNum = 1;
            CallExplosion();
            return;
        }
        else if(sliceNum % 2 == 1)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        }
        else if(sliceNum % 2 == 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255f);
        }

        sliceNum++;
        Invoke("TurnLight", (waitDuration / turnDuration));
    }

    void CallExplosion()
    {
        animator.SetBool("isExplosion", true);
        bc2.enabled = true;
        Invoke("EndExplosion", 0.75f);
    }

    void EndExplosion() 
    {
        animator.SetBool("isExplosion", false);
        bc2.enabled = false;
        Invoke("TurnLight", (waitDuration / turnDuration));
    }
}
