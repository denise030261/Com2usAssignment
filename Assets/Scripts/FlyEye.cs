using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye : Enemy
{
    [SerializeField]
    Vector3 movePoint2;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float delaySeconds;

    [SerializeField]
    bool isStatic;

    Vector3 movePoint1;
    Vector3 targetPosition;
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
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        if (transform.position == targetPosition && !isArrive && !isStatic)
        {
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

        movingToEnd = !movingToEnd;
        isArrive = false;
    }

    private void Init()
    {
        flipScale = transform.localScale.x;
        isArrive = false;
        targetPosition = movePoint2;
        movePoint1 = transform.position;
    }
}
