using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMonitor : MonoBehaviour
{
    private SpeedDisplay auto;
    public AudioSource sound;
    public GameObject carGroup;
    public Score grade;
    private bool ready;
    private bool stop;

    void Start()
    {
        auto = carGroup.GetComponentInChildren<SpeedDisplay>();
        ready = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            if (auto.carSpeed < 0.05f && stop == false)
            {
                stop = true;
                grade.score -= 5;
                sound.Play();
            }
            else if(auto.carSpeed > 0.5f)
            {
                stop = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ready = ready ? false : true;
        }
    }
}
