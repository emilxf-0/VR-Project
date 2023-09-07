using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAmbienceSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip ambientSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the audio clip
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
