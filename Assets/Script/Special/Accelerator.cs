using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    private SpeedDisplay auto;
    public GameObject carGroup;
    public GameObject acceleratorUI;
    private float shark;

    void Start()
    {
        auto = carGroup.GetComponentInChildren<SpeedDisplay>();
        acceleratorUI.SetActive(false);
        shark = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (auto.carSpeed < 1)
        {
            shark += Time.deltaTime;
            if(shark % 1 >0.4f)
                acceleratorUI.SetActive(true);
            else
                acceleratorUI.SetActive(false);
        }
        else
            acceleratorUI.SetActive(false);
    }
}
