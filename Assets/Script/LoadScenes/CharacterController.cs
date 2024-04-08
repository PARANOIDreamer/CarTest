using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject[] characterList;
    private int idnum;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var o in characterList)
            o.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        idnum = KeepData.Instance.number;
        foreach (var o in characterList)
            o.SetActive(false);
        characterList[idnum].SetActive(true);
    }
}
