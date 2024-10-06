using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip landSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.ignoreListenerPause = true;
    }

    public void JumpSFX()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void DieSFX()
    {
        audioSource.PlayOneShot(dieSound);
    }

    public void LandSFX()
    {
        audioSource.PlayOneShot(landSound);
    }


    void Update()
    {
        
    }
}
