using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    GameObject turnOff;

    [SerializeField]
    GameObject turnOn;

    [SerializeField]
    GameObject obstruction;

    AudioSource audioOpen;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        turnOff.SetActive(true);
        turnOn.SetActive(false);
        obstruction.SetActive(true);
        audioOpen = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            turnOff.SetActive(false);
            turnOn.SetActive(true);
            obstruction.SetActive(false);
            audioOpen.Play();
        }
    }
}
