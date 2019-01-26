using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSFX : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] impact;
    private AudioClip impactClip;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void PlaySoundeffects()
    {
        int index = Random.Range(0, impact.Length);
        impactClip = impact[index];
        audioSource.clip = impactClip;
        audioSource.Play();
    }
    void Update()
    {

    }
}
