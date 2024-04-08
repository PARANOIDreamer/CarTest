using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject[] characterList;
    public CarControl[] cars;
    public LightsControl[] lights;
    public CameraControl[] VrHeads;
    private int idnum;

    // Start is called before the first frame update
    void Start()
    {
        idnum = KeepData.Instance.number;
        //idnum = 0;
        foreach (var o in characterList)
            o.SetActive(false);
        characterList[idnum].SetActive(true);
    }

    public void AccelerateOn()
    {
        cars[idnum].AccelerateOn();
    }

    public void AccelerateOff()
    {
        cars[idnum].AccelerateOff();
    }

    public void BrakeOn()
    {
        cars[idnum].BrakeOn();
    }

    public void BrakeOff()
    {
        cars[idnum].BrakeOff();
    }

    public void Right()
    {
        cars[idnum].Right();
    }

    public void Left()
    {
        cars[idnum].Left();
    }

    public void FreeHand()
    {
        cars[idnum].FreeHand();
    }

    public void GearChange()
    {
        cars[idnum].GearChange();
    }

    public void LeftSwith()
    {
        lights[idnum].LeftSwith();
    }

    public void RightSwith()
    {
        lights[idnum].RightSwith();
    }

    public void ChangeCamera()
    {
        VrHeads[idnum].ChangeCamera();
    }
}
