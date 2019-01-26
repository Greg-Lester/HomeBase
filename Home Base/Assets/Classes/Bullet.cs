using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update() {}
    void OnCollisionEnter2D(Collision2D col) {
 
 
        {
            //Check collision name
            Debug.Log("collision name = " + col.gameObject.name);
            if (col.gameObject.name == "Block(Clone)")
            {
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
