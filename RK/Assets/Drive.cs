using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider[] WC;
    public GameObject[] Wheels;
    public float torque = 200;
    public float maxSteerAngle = 30;
    public GameObject Wheel;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        float thrustTorque = accel * torque;
        for(int i = 0; i < 4; i++)
        {
            WC[i].motorTorque = thrustTorque;

            if(i < 2)
                WC[i].steerAngle = steer;

            Quaternion quat;
            Vector3 postion;
            WC[i].GetWorldPose(out postion, out quat);
            Wheels[i].transform.position = postion;
            Wheels[i].transform.rotation = quat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        Go(a,s);
    }
}
