﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ImpactSFX sfx;
    private bool _decaying = false;
    private bool _has_hit_floor = false;
    public ParticleSystem Explosion;

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
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        var v = rb.velocity;
        var gameblock = col.gameObject.GetComponent<GameBlock>();
        if (gameblock != null) {
            var crackedSprite = gameblock.Cracked;
            var sqrSpeed = v.sqrMagnitude;
            var spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
            if (sqrSpeed > 300f || spriteRenderer.sprite == crackedSprite && gameblock.CanBeDamagedBy(this)) 
            {
                sfx.PlaySoundeffects();
                Destroy(col.gameObject, 0.05f);
                Instantiate(Explosion, col.gameObject.transform.position, Quaternion.identity);
            }
            else if (sqrSpeed > 50.0f)
            {
                gameblock.MarkAsDamagedBy(this);
                spriteRenderer.sprite = crackedSprite;
                sfx.PlayDamagedSoundeffects();
            }
        }
        if (col.gameObject.name == "Floor")
        {
            v.y = 0;
            rb.velocity = v;
            if (!_has_hit_floor)
            {
                sfx.PlayFloorSoundeffects();
                this._has_hit_floor = true;
            }
        }

        var bb = col.gameObject.GetComponent<BaseBuilder>();
        if (bb != null)
        {
            sfx.PlayCharacterHitSoundeffects();
            bb.onPlayerWin();
        }
     }
}
