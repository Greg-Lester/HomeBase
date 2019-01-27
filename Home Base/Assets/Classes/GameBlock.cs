using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlock : MonoBehaviour
{
    public Sprite Cracked;
    private bool _has_collided = false;
    public AudioClip spawnSound;
    public AudioClip blockCollideSound;
    private AudioSource audioSource;

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
            audioSource.clip = blockCollideSound;
            audioSource.Play();
        }
    }
}
