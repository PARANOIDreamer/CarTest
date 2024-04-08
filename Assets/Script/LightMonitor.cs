using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMonitor : MonoBehaviour
{
    public bool leftOn;
    public bool rightOn;
    private LightsControl carLight;
    public GameObject carGroup;
    public Score grade;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        carLight = carGroup.GetComponentInChildren<LightsControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (carLight.leftActive == leftOn && carLight.rightActive == rightOn)
            {
                grade.score -= 0;
            }
            else
            {
                grade.score -= 10;
                sound.Play();
            }
        }
    }
}
