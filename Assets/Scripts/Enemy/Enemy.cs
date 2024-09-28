using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] MoveStrategy moveStrategy = null;
    [SerializeField] AttackStrategy attackStrategy = null;
    [SerializeField] GameObject targetObject = null;
    [SerializeField] float _turnTime = 1f;

    Vector3 targetPosition;
    Vector3 originPosition;
    bool movingToEnd = true;
    bool isArrive = false;
    bool isAttack = true;
    Animator animator;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (moveStrategy != null)
        {
            transform.position = moveStrategy.Move(transform.position, targetPosition);
        }
        if ((Mathf.Abs(transform.position.x - targetPosition.x)<=0.01 && Mathf.Abs(transform.position.y - targetPosition.y) <= 0.01) 
            && !isArrive)
        {
            animator.SetBool("isMove", false);
            isArrive = true;
            Invoke("Delay", _turnTime);
        }

        if(attackStrategy != null) 
        {
            if(isAttack)
            {
                StartCoroutine(AttackCorutine());
            }
            else
            {
                animator.SetBool("isAttack", false);
            }
        }
    }

    IEnumerator AttackCorutine()
    {
        animator.SetBool("isAttack", true);
        isAttack = false;
        yield return StartCoroutine(attackStrategy.Attack(this));
        isAttack = true;
    }


    void Delay()
    {
        if (moveStrategy != null)
        {
            moveStrategy.Turn(this, ref targetPosition, originPosition, targetObject.transform.position, ref movingToEnd);
        }
        animator.SetBool("isMove", true);
        isArrive = false;
    }

    private void Init()
    {
        targetPosition = targetObject.transform.position;
        originPosition = transform.position;
        animator = GetComponent<Animator>();
    }
}
