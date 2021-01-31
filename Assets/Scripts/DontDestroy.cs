using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
       // GameObject[] objects = GameObject.FindGameObjectsWithTag("DontDestroy");
        

        DontDestroyOnLoad(this.gameObject);

    }
}
