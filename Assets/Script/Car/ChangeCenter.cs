using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCenter : MonoBehaviour
{
    public Vector3 center;
    private Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.centerOfMass = center;
    }

}
