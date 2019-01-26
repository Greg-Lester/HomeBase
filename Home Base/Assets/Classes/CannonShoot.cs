using UnityEngine;
using System.Collections;

public class CannonShoot : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public CannonSFX script;


    // Use this for initialization
    void Start()
    {
        Shoot(0, 0, 6, 8);
    }

    void Shoot(float x, float y, float dx, float dy)
    {
        GameObject cannonball = Instantiate(ProjectilePrefab, new Vector3(x, y, 0), Quaternion.identity);
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(dx, dy, 0);
        script.PlaySoundeffects();
    }

}
