using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    [SerializeField]
    Vector3 movePoint2;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float delaySeconds;

    [SerializeField]
    bool isStatic;

    Vector3 targetPosition;
    Vector3 movePoint1;
    float flipScale;
    bool movingToEnd = true;
    bool isArrive;
    Animator animator;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if(!isStatic)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition && !isArrive && !isStatic)
        {
            animator.SetBool("isMove", false);
            isArrive = true;
            Invoke("Delay", delaySeconds);
        }
    }


    void Delay()
    {
        if (movingToEnd)
        {
            targetPosition = movePoint1; // Move Location1
            transform.localScale = new Vector3(-flipScale, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            targetPosition = movePoint2; // Move Location2
            transform.localScale = new Vector3(flipScale, transform.localScale.y, transform.localScale.z);
        }

        animator.SetBool("isMove", true);
        movingToEnd = !movingToEnd;
        isArrive = false;
    }

    private void Init()
    {
        flipScale = transform.localScale.x;
        targetPosition = movePoint2;
        movePoint1 = transform.position;

        isArrive = false;
        animator = GetComponent<Animator>();

        if(isStatic)
        {
            animator.SetBool("isMove", false);
        }
    }
}
