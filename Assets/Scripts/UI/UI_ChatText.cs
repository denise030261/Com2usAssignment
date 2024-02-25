using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChatText : MonoBehaviour
{
    [SerializeField]
    string ChatText;

    [SerializeField]
    int CharPerSecnds;
    
    Text chatingText;
    int index;
    float interval;

    // Start is called before the first frame update
    void Start()
    {
        chatingText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        if (gameObject.activeSelf)
        {
            ChatText = ChatText.Replace("\\n", "\n");
            EffectStart();
        }
    }

    void EffectStart()
    {
        index = 0;

        interval = 1.0f / CharPerSecnds;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        if (chatingText.text == ChatText)
        {
            return;
        }
        chatingText.text += ChatText[index];
        index++;

        Invoke("Effecting", interval);
    }
}
