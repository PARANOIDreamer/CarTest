using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsControl : MonoBehaviour
{
    public GameObject rightLight;
    public GameObject leftLight;
    public GameObject rightSignal;
    public GameObject leftSignal;
    public bool leftActive;
    public bool rightActive;
    private bool swithL;
    private bool swithR;

    // Start is called before the first frame update
    void Start()
    {
        rightLight.SetActive(false);
        leftLight.SetActive(false);
        rightSignal.SetActive(false);
        leftSignal.SetActive(false);
        swithL = false;
        swithR = false;
        leftActive = false;
        rightActive = false;
    }

    public void LeftSwith()
    {
        swithL = swithL ? false : true;
        leftLight.SetActive(swithL);
        leftSignal.SetActive(swithL);
        leftActive = swithL;
    }

    public void RightSwith()
    {
        swithR = swithR ? false : true;
        rightLight.SetActive(swithR);
        rightSignal.SetActive(swithR);
        rightActive = swithR;
    }
}
