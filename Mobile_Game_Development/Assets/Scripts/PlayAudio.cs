using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Plays sound effect chosen
    public void soundFunction()
    {
        audioSource.PlayOneShot(soundEffect);
    }
}
