using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
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

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (!isStatic)
            transform.position = Vector3.Slerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition && !isArrive && !isStatic)
        {
            if(movingToEnd)
            {
                transform.localScale = new Vector3(-flipScale, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(flipScale, transform.localScale.y, transform.localScale.z);
            }

            isArrive = true;
            Invoke("Delay", delaySeconds);
        }
    }


    void Delay()
    {
        if (movingToEnd)
        {
            targetPosition = movePoint1; // Move Location1
        }
        else
        {
            targetPosition = movePoint2; // Move Location2
        }

        movingToEnd = !movingToEnd;
        isArrive = false;
    }

    private void Init()
    {
        flipScale = transform.localScale.x;
        targetPosition = movePoint2;
        movePoint1 = transform.position;

        isArrive = false;
    }
}
