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

        float clockSpeed = -360f / fillDuration; // �ð�ٴ��� �ӵ� (1�ʿ� �����̴� ����)
        float rotationAngle = clockSpeed * fillTimer; // �ð�ٴ��� 1���� ���µ� �ɸ��� �ð��� ����
        ClockStick.transform.localEulerAngles = new Vector3(0f, 0f, rotationAngle);
    }

    void Init()
    {
        itemCountObject.SetActive(false);
        gameResultDisplay.SetActive(false);
        Time.timeScale = 1;
    }
}



