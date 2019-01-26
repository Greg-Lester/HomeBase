using UnityEngine;
using System.Collections;

public class BaseBuilder : MonoBehaviour
{
    public GameObject WallPrefab;


    // Use this for initialization
    void Start()
    {
        Block[] testArray = new Block[]{
            new Block(3, 1),
            new Block(2, 3),
            new Block(1, 4),
            new Block(5, 2),
            new Block(4, 6)
        };
        this.BuildBase(testArray);
    }

   void BuildBase(Block[] blocks){
        foreach(Block b in blocks)
            Instantiate(WallPrefab, new Vector3(b.x, b.y, 0), Quaternion.identity);
        
    }

}
