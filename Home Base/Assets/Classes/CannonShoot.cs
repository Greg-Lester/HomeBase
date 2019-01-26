using UnityEngine;
using System.Collections;

public class CannonShoot : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public CannonSFX script;


    // Use this for initialization
    void Start()
    {
    }

    public void Shoot(float dx, float dy, int layer_id)
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        GameObject cannonball = Instantiate(ProjectilePrefab, new Vector3(x, y, 0), Quaternion.identity);
        cannonball.layer = layer_id;
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        float MAG = 0.08f;
        rb.velocity = new Vector3(dx* MAG, -dy * MAG, 0);
        
        script.PlaySoundeffects();
    }

}
