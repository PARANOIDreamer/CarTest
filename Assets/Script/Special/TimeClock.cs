using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeClock : MonoBehaviour
{
    private int hour;
    private int minute;
    private int second;
    private float timeSpend;
    private bool ready;
    public Text text_timeSpend;

    // Start is called before the first frame update
    void Start()
    {
        hour = 0;
        minute = 0;
        second = 0;
        timeSpend = 0.0f;
        ready = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            timeSpend += Time.deltaTime;
            hour = (int)timeSpend / 3600;
            minute = ((int)timeSpend - hour * 3600) / 60;
            second = (int)timeSpend - hour * 3600 - minute * 60;
        }
        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ready = ready ? false : true;
        }
    }
}
