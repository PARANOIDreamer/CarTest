using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform first;
    public Transform thrid;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = first.position;
        num = 0;
    }

    public void ChangeCamera()
    {
        switch (num)
        {
            case 0:
                transform.position = thrid.position;
                num = 1;
                break;
            case 1:
                transform.position = first.position;
                num = 0;
                break;
        }
    }
}
