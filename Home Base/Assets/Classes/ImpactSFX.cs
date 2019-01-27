using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSFX : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] impact;
    public AudioClip[] damaged;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void PlaySoundeffects()
    {
        int index = Random.Range(0, impact.Length);
        var impactClip = impact[index];
        audioSource.clip = impactClip;
        audioSource.Play();
    }
    public void PlayDamagedSoundeffects()
    {
        int index = Random.Range(0, damaged.Length);
        var damagedClip = damaged[index];
        audioSource.clip = damagedClip;
        audioSource.Play();
    }
}
