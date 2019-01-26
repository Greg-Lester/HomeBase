using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ImpactSFX sfx;
    public Sprite crackedSprite;
    private bool _decaying = false;
    private bool _has_hit_floor = false;
    void Update() {
        if (_decaying)
        {
            var renderer = this.GetComponent<SpriteRenderer>();
            var color = renderer.color;
            color.a -= 0.02f;
            renderer.color = color;
            if (color.a <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        var sqrSpeed = rb.velocity.sqrMagnitude;

        if(_decaying && sqrSpeed > 3 && !_has_hit_floor)
        {
            var renderer = this.GetComponent<SpriteRenderer>();
            var color = renderer.color;
            color.a = 1.0f;
            renderer.color = color;
        }

        if (sqrSpeed < 3)
        {
            _decaying = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col) 
    {

        this._decaying = true;
        this._has_hit_floor = true;
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        var v = rb.velocity;
        var gameblock = col.gameObject.GetComponent<GameBlock>();
        if (gameblock != null) {
            var sqrSpeed = v.sqrMagnitude;
            var spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
            if (sqrSpeed > 300f || spriteRenderer.sprite == crackedSprite && gameblock.CanBeDamagedBy(this)) 
            {
                sfx.PlaySoundeffects();
                Destroy(col.gameObject, 0.05f);
            }
            else if (sqrSpeed > 50.0f)
            {
                gameblock.MarkAsDamagedBy(this);
                spriteRenderer.sprite = crackedSprite;
            }
        }
        if (col.gameObject.name == "Floor")
        {
            v.y = 0;
            rb.velocity = v;

          
        }
     }
}
