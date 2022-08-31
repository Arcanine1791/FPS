using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrigger : MonoBehaviour
{
    public AudioClip triggerSound;
    AudioSource audioSource;
    
    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerSound != null)
        {
            audioSource.PlayOneShot(triggerSound, 0.7f);


        }
    }
}