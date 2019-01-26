using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        if (col.gameObject.name == "Block(Clone)" || col.gameObject.name == "Block")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "Floor")
        {
            this._decaying = true;
            this._has_hit_floor = true;
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            var v = rb.velocity;
            v.y = 0;
            rb.velocity = v;
        }
     }
}
