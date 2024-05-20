using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MniPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
            rectTransform.anchoredPosition = new Vector2(player.transform.position.x*(43.0f/23.3f), player.transform.position.y*3);
    }
}
