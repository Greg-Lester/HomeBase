using UnityEngine;
using System.Collections;

public class CannonShoot : MonoBehaviour
{
    public Bullet ProjectilePrefab;
    public CannonSFX script;
    public ImpactSFX impactSfx;

    // Use this for initialization
    void Start()
    {
    }

    public void Shoot(float dx, float dy, int layer_id)
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        Bullet cannonball = Instantiate(ProjectilePrefab, new Vector3(x, y, 0), Quaternion.identity);
        cannonball.sfx = impactSfx;
        cannonball.gameObject.layer = layer_id;
        SpriteRenderer renderer = cannonball.GetComponent<SpriteRenderer>();
        var playerRenderer = GetComponent<MeshRenderer>();
        var srcColor = playerRenderer.material.color;
        renderer.color = srcColor;

        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        float MAG = 0.08f;
        rb.velocity = new Vector3(dx* MAG, -dy * MAG, 0);
        
        script.PlaySoundeffects();
    }

}
