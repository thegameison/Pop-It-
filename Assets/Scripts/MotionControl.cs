using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl: MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Vector3 startEulerAngles;
    private Vector3 startGyroAttitudeToEuler;
    public float adjustmentAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = EnableGyro();
        startEulerAngles = transform.eulerAngles;
        startEulerAngles.x = 0.0f;
        startEulerAngles.y = 0.0f;
        startEulerAngles.z = 0.0f;
        startGyroAttitudeToEuler = gyro.attitude.eulerAngles;
        startGyroAttitudeToEuler.x = 0.0f;
        startGyroAttitudeToEuler.y = 0.0f;
        startGyroAttitudeToEuler.z = 0.0f;
    }

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(gyroEnabled)
        {
            Vector3 deltaEulerAngles = gyro.attitude.eulerAngles - startGyroAttitudeToEuler;
            deltaEulerAngles.x = 0.0f;
            deltaEulerAngles.y = 0.0f;
            //transform.eulerAngles = new Vector3(0, 0, startEulerAngles.z - deltaEulerAngles.z);
            transform.rotation = Quaternion.Euler(0,0,-deltaEulerAngles.z-adjustmentAngle);
        }
    }
}
