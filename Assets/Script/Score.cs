using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public PlayAgain pause;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        score = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 80)
        {
            sound.Play();
            pause.onStop = true;
        }
    }
}
