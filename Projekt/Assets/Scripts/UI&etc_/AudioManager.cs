using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;


    private void Awake()
    {
        
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
            audioSource = GetComponent<AudioSource>();
        
    }

    

   
}
