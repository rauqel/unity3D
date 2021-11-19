using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public Transform switchPosition;
    public Transform onSwitch;
    public Transform offSwitch;
    public Transform hinge;

    public float switchSpeed;

    bool isOff = true;

    // Start is called before the first frame update
    void Start()
    {
        switchPosition.position = offSwitch.position;
    }

    private void onTriggerEnter()
    {
        if (isOff)
        {
            switchPosition.position = Vector3.MoveTowards(switchPosition.position, onSwitch.position, switchSpeed);
            hinge.position = Vector3.MoveTowards(hinge.position, hinge.position, 0.0f);
            isOff = false;
        }
    }
}
