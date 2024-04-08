using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation : MonoBehaviour
{
    public Score grade;
    public AudioSource sound;
    public int score = 100;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            grade.score -= score;
            sound.Play();
        }
    }
}
