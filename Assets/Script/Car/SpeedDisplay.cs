using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Text text_carSpend;
    private Rigidbody r;
    public float carSpeed;
    public GameObject needle;
    private float angle;
    public AudioSource sound;

    // Use this for initialization
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        carSpeed = r.velocity.magnitude;
        text_carSpend.text = carSpeed.ToString("0.0") + "km/h";
        angle = 180 - carSpeed * 20;
        angle = Mathf.Clamp(angle, -90, 180);
        needle.transform.localRotation = Quaternion.Euler(0, 0, angle);
        if (carSpeed > 0.1f)
        {
            sound.Play();
        }
        else
        {
            sound.Stop();
        }
    }
}
