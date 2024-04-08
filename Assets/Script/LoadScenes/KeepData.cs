using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepData : MonoBehaviour
{
    public static KeepData Instance { get; private set; }
    public int number { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    void Start()
    {
        number = 4;
    }
}
