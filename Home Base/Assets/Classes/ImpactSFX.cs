using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSFX : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] impact;
    public AudioClip[] damaged;
    public AudioClip[] floor;
    public AudioClip[] characterHit;
    public AudioClip[] blockCollideSound;

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
    public void PlayFloorSoundeffects()
    {
        int index = Random.Range(0, floor.Length);
        var floorClip = floor[index];
        audioSource.clip = floorClip;
        audioSource.Play();
    }
    public void PlayCharacterHitSoundeffects()
    {
        int index = Random.Range(0, characterHit.Length);
        var characterHitClip = characterHit[index];
        audioSource.clip = characterHitClip;
        audioSource.Play();
    }
    public void PlayBlockCollideSound()
    {
        int index = Random.Range(0, blockCollideSound.Length);
        var blockCollideSoundClip = blockCollideSound[index];
        audioSource.clip = blockCollideSoundClip;
        audioSource.Play();
    }
}
