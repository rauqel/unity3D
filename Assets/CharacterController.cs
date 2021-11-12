using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody myRigidbody;

    public float maxSpeed;
    public float playerSpeed = 3.0f;
    public float sprintSpeed = 17.0f;
    public float maxSprint = 5.0f;
    float sprintTimer;

    public CapsuleCollider height;
    bool crouching = false;

    public float rotation = 0.0f;
    public float camRotation = 0.0f;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    GameObject cam;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

    public float jumpForce = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();

        sprintTimer = maxSprint;
    }

    // Update is called once per frame
    void Update()
    {
        //movement mechanics
        Vector3 forwardsVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed;

        Vector3 sidewaysVelocity = transform.right * Input.GetAxis("Horizontal") * maxSpeed;

        Vector3 finalVelocity = forwardsVelocity + sidewaysVelocity;

        myRigidbody.velocity = new Vector3(finalVelocity.x, myRigidbody.velocity.y, finalVelocity.z);

        //sprint and stamina
        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }
        else
        {
            maxSpeed = playerSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                sprintTimer = sprintTimer + Time.deltaTime;
            }
        }

        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        //rotation mechanics
        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));
        //                                               (  X ,    Y    ,  Z  )

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));

        //jump mechanics
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
        }

        //crouch mechanic
        height = GetComponent<CapsuleCollider>();

        if (Input.GetKeyDown(KeyCode.C) && isOnGround && (crouching == false))
        {
            crouching = true;
            height.height = new Vector3(1.0f, 0.3f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.C) && isOnGround && (crouching == true))
        {
            crouching = false;
            height.height = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
