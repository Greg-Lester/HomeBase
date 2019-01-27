using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlock : MonoBehaviour
{
    public Sprite Cracked;
    private List<Bullet> damagedBy = new List<Bullet>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MarkAsDamagedBy(Bullet attacker)
    {
        damagedBy.Add(attacker);
    }

    public bool CanBeDamagedBy(Bullet attacker)
    {
        return !damagedBy.Contains(attacker);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
