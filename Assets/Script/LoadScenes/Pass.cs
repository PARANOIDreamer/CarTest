using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    public AudioSource sound;
    public PlayAgain pause;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
            pause.onStop = true;
        }
    }
}
