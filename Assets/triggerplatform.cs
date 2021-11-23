using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerplatform : MonoBehaviour
{
    public Movingplatform platform;
    float timer = 5;
    public Movingplatform trigger;

    private void OnTriggerEnter(Collider collision)
    {
        if (!trigger.isActive)
        {
            if (collision.gameObject.tag == "Player")
            {
                platform.isMoving = true;
                trigger.isActive = true;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                platform.isMoving = false;
                trigger.isActive = false;
            }
        }
    }
}