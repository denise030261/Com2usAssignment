using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField]
    GameObject itemCountObject;

    [SerializeField]
    GameObject gameResultDisplay;

    public Image circleImage;
    public GameObject ClockStick;
    public float fillDuration = 30f; // Time duration
    float fillTimer = 0f;

    public static Clock Instance { get; private set; } = null;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (fillTimer < fillDuration)
        {
            ClockMove();
        }

        if (fillTimer >= fillDuration)
        {
            gameResultDisplay.SetActive(true);
            itemCountObject.SetActive(true);
            circleImage.fillAmount = 1;
            ClockStick.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void ClockMove()
    {
        fillTimer += Time.deltaTime;

        float fillAmount = fillTimer / fillDuration;
        circleImage.fillAmount = fillAmount;

        float clockSpeed = -360f / fillDuration; // 시계바늘의 속도 (1초에 움직이는 각도)
        float rotationAngle = clockSpeed * fillTimer; // 시계바늘이 1바퀴 도는데 걸리는 시간과 맞춤
        ClockStick.transform.localEulerAngles = new Vector3(0f, 0f, rotationAngle);
    }

    void Init()
    {
        itemCountObject.SetActive(false);
        gameResultDisplay.SetActive(false);
        Time.timeScale = 1;
    }
}



