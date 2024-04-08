using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMonitor : MonoBehaviour
{
    public Order counter;
    public int[] number;
    private int frequency;
    public Score grade;
    private int i;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        frequency = 0;
    }

    // Update is called once per frame
    void Update()
    {
        i = frequency;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (counter.serialNum == number[i]-1)
            {
                counter.serialNum = number[i];
                frequency += 1;
            }
            else
            {
                grade.score -= 100;
                sound.Play();
            }
        }
    }
}
