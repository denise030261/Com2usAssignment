using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Camera mapCamera;

    [SerializeField]
    float moveX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(collision.transform.position.x>transform.transform.position.x)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x - moveX, mapCamera.transform.position.y
                    , mapCamera.transform.position.z);
            }
            else
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x + moveX, mapCamera.transform.position.y
                    , mapCamera.transform.position.z);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x > transform.transform.position.x
                && mapCamera.transform.position.x < transform.transform.position.x)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x+moveX, mapCamera.transform.position.y
                    , mapCamera.transform.position.z);
            }
            else if (collision.transform.position.x < transform.transform.position.x
                && mapCamera.transform.position.x > transform.transform.position.x)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x-moveX, mapCamera.transform.position.y
                    , mapCamera.transform.position.z);
            }
        }
    }
}
