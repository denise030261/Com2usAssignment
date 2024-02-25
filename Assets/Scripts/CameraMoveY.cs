using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveY : MonoBehaviour
{
    [SerializeField]
    Camera mapCamera;

    [SerializeField]
    float moveY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.y > transform.transform.position.y)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, mapCamera.transform.position.y-moveY
                    , mapCamera.transform.position.z);
            }
            else
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, mapCamera.transform.position.y+moveY
                    , mapCamera.transform.position.z);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.y > transform.transform.position.y
                && mapCamera.transform.position.y<transform.transform.position.y)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, mapCamera.transform.position.y + moveY
                    , mapCamera.transform.position.z);
            }
            else if (collision.transform.position.y < transform.transform.position.y
                && mapCamera.transform.position.y > transform.transform.position.y)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, mapCamera.transform.position.y - moveY
                    , mapCamera.transform.position.z);
            }
        }
    }
}

