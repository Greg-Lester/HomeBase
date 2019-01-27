using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlock : MonoBehaviour
{
    public Sprite Cracked;
    private bool _has_collided = false;
    public AudioClip spawnSound;
    private AudioSource audioSource;
    public AudioClip[] collideSound;

    private List<Bullet> damagedBy = new List<Bullet>();
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = spawnSound;
        audioSource.Play();
    }

    public void MarkAsDamagedBy(Bullet attacker)
    {
        damagedBy.Add(attacker);
    }

    public bool CanBeDamagedBy(Bullet attacker)
    {
        return !damagedBy.Contains(attacker);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!_has_collided)
        {
            _has_collided = true;
            PlayBlockCollideSound();
        }
    }

    public void PlayBlockCollideSound()
    {
        int index = Random.Range(0, collideSound.Length);
        var blockCollideSoundClip = collideSound[index];
        audioSource.clip = blockCollideSoundClip;
        audioSource.Play();
    }
}
