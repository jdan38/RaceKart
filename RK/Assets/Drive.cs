using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider WC;
    public float torque = 200;
    // Start is called before the first frame update
    void Start()
    {
        WC = this.GetComponent<WheelCollider>();
    }

    void Go(float accel)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        float thrustTorque = accel * torque;
        WC.motorTorque = thrustTorque;

        Quaternion quat;
        Vector3 postion;
        WC.GetWorldPose(out postion, out quat);
        this.transform.position = postion;
        this.transform.rotation = quat;
    }

    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxis("Vertical");
        Go(a);
    }
}
