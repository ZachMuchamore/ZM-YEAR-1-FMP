using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    public static GlobalReferences instance;

    public int waveNumber;
    public int zombieNumber;

    public bool hasDied;


    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
