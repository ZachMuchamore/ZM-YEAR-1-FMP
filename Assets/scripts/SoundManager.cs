using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{
   public static SoundManager Instance { get; set; }

    public AudioSource shootingSoundM1911;

    public void Awake()
    {
        if( Instance == null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
