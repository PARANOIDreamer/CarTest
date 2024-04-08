using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boardcast : MonoBehaviour
{
    public AudioSource sound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
        }
    }
}
