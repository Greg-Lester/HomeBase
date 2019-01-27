using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDamageSFX : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] damagesfx;
    private AudioClip damagesfxClip;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void PlaySoundeffects()
    {
        int index = Random.Range(0, damagesfx.Length);
        damagesfxClip = damagesfx[index];
        audioSource.clip = damagesfxClip;
        audioSource.Play();
    }
    void Update()
    {

    }
}
