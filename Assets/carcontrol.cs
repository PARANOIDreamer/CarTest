using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontrol : MonoBehaviour
{
    public AudioSource sound;
    public GameObject[] wheelMesh;
    public GameObject axisSteer;
    public GameObject exhaust;
    public GameObject[] rearLights;
    private WheelCollider[] wheel;
    private float maxAnge;
    private float maxToque;
    private Rigidbody r;
    private bool neutral;
    private bool reverse;
    private bool parking;
    private bool forward;
    private bool accelerator;
    private bool brake;
    private bool turnRight;
    private bool turnLeft;
    private float toque;
    private float angle;
    private int gear;
    public GameObject[] gearUI;

    // Start is called before the first frame update
    void Start()
    {
        maxAnge = 30;
        maxToque = 200;
        wheel = transform.GetChild(2).GetComponentsInChildren<WheelCollider>();
        foreach(var o in rearLights)
        {
            o.SetActive(false);
        }
        r = GetComponent<Rigidbody>();
        neutral = true;
        reverse = false;
        parking = false;
        forward = false;
        exhaust.SetActive(false);
        accelerator = false;
        brake = false;
        turnRight = false;
        turnLeft = false;
        toque = 0;
        angle = 0;
        gear = 0;
        for(int i = 1; i < 4; i++)
        {
            gearUI[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (turnLeft)
        {
            angle -= 2f;
            angle = Mathf.Clamp(angle, -maxAnge, maxAnge);
        }
        else
        {
            if (turnRight)
            {
                angle += 2f;
                angle = Mathf.Clamp(angle, -maxAnge, maxAnge);
            }
            else
            {
                angle = Mathf.MoveTowards(angle, 0, 30 * Time.deltaTime);
            }
        }
        if (angle != 0)
        {
            for(int i = 0; i < 2; i++)
            {
                wheel[i].steerAngle = angle;
            }
        }
        if (accelerator)
        {
            SpeedUp();
        }
        else
        {
            SpeedOff();
        }
        if (neutral)
        {
            exhaust.SetActive(false);
            foreach(var o in wheel)
            {
                o.motorTorque = 0;
            }
            if (brake)
            {
                foreach(var o in wheel)
                {
                    o.brakeTorque = 500;
                }
            }
            else
            {
                foreach (var o in wheel)
                {
                    o.brakeTorque = 0;
                }
            }
        }
        if (parking)
        {
            exhaust.SetActive(false);
            foreach (var o in wheel)
            {
                o.motorTorque = 0;
                o.brakeTorque = 500;
            }
        }
        if (forward)
        {
            exhaust.SetActive(true);
            if (brake)
            {
                foreach (var o in wheel)
                {
                    o.brakeTorque = 500;
                }
            }
            else
            {
                foreach (var o in wheel)
                {
                    o.brakeTorque = 0;
                }
            }
            if (toque != 0)
            {
                foreach(var o in wheel)
                {
                    o.motorTorque = toque;
                }
            }
        }
        if (reverse)
        {
            exhaust.SetActive(true);
            if (brake)
            {
                foreach (var o in wheel)
                {
                    o.brakeTorque = 500;
                }
            }
            else
            {
                foreach (var o in wheel)
                {
                    o.brakeTorque = 0;
                }
            }
            if (toque != 0)
            {
                foreach (var o in wheel)
                {
                    o.motorTorque = -toque;
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            wheelMesh[i].transform.localRotation = Quaternion.Euler(wheel[i].rpm * 360 / 60, wheel[i].steerAngle, 0);
        }
        axisSteer.transform.localRotation = Quaternion.Euler(0, 0, angle * -3);
    }

    void AccelerateOn()
    {
        accelerator = true;
    }

    void AccelerateOff()
    {
        accelerator = false;
    } 

    private void SpeedUp()
    {
        toque += 100f;
        toque = Mathf.Clamp(toque, 10, maxToque);
    }

    private void SpeedOff()
    {
        toque -= 100f;
        toque = Mathf.Clamp(toque, 10, maxToque);
    }

    void BrakeOn()
    {
        brake = true;
        foreach(var o in rearLights)
        {
            o.SetActive(true);
        }
    }

    void Brakeff()
    {
        brake = false;
        foreach (var o in rearLights)
        {
            o.SetActive(false);
        }
    }

    void Right()
    {
        turnRight = true;
        turnLeft = false;
    }

    void Left()
    {
        turnRight = false;
        turnLeft = true;
    }

    void FreeHand()
    {
        turnRight = false;
        turnLeft = false;
    }

    void GearChange()
    {
        if (r.velocity.magnitude < 0.2f)
        {
            sound.Play();
            switch (gear)
            {
                case 0:
                    forward = true;
                    neutral = false;
                    gearUI[1].SetActive(true);
                    gearUI[0].SetActive(false);
                    gear = 1;
                    break;
                case 1:
                    forward = false;
                    reverse = true;
                    gearUI[2].SetActive(true);
                    gearUI[1].SetActive(false);
                    gear = 2;
                    break;
                case 2:
                    parking = true;
                    reverse = false;
                    gearUI[3].SetActive(true);
                    gearUI[2].SetActive(false);
                    gear = 3;
                    break;
                case 3:
                    neutral = true;
                    parking = false;
                    gearUI[0].SetActive(true);
                    gearUI[3].SetActive(false);
                    gear = 0;
                    break;
            }
        }
    }
}
