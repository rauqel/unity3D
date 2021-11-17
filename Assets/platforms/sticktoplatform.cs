using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticktoplatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
