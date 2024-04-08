using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnsign : MonoBehaviour
{
    public GameObject turnUI;
    private bool isShow;
    public int number;
    public bool exit;
    private int frequency;

    void Start()
    {
        turnUI.SetActive(false);
        frequency = -1;
    }

    // Update is called once per frame
    void Update()
    {
        turnUI.SetActive(isShow);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!exit)
            {
                frequency += 1;
                if (frequency == number)
                {
                    isShow = true;
                }
            }
            else
            {
                isShow = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (exit)
            {
                frequency += 1;
                if (frequency == number)
                {
                    isShow = true;
                }
            }
            else
            {
                isShow = false;
            }
        }
    }
}
