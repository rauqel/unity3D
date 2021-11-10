using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    public float rotation = 0.0f;
    public float camRotation = 0.0f;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //data types are
            //[vector 3]}-----------------------------------------------   [float]}----------------
            transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * playerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * playerSpeed / 4);
        }
        transform.position = transform.position + (transform.right * Input.GetAxis("Horizontal") * playerSpeed / 4);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));
        //...............................................(  X ,    Y    ,  Z  )

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));
    }
}
