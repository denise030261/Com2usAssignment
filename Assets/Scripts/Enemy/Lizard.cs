using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Enemy
{
    [SerializeField]
    float delaySeconds;

    [SerializeField]
    GameObject fireBall;

    [SerializeField]
    float fireballDistance;

    FireBall fireballScript;
    Animator animator;
    bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Invoke("Delay", delaySeconds);
    }

    // Update is called once per frame
    void Update()
    {
        if(isShoot)
        {
            animator.SetBool("isShoot", true);
            isShoot = false;
            Invoke("Fire", 0.3f);
            Invoke("Delay", delaySeconds);
        }
        else
        {
            animator.SetBool("isShoot", false);
        }
    }

    void Delay()
    {
        isShoot = true;
    }

    void Fire()
    {
        fireballScript = fireBall.GetComponent<FireBall>();
        fireballScript.distance = fireballDistance;
        Instantiate(fireBall, transform.position, Quaternion.identity);
    }

    private void Init()
    {
        isShoot = false;
        animator = GetComponent<Animator>();
    }
}
