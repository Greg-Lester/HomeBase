using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseBuilder : MonoBehaviour
{
    public GameObject WallPrefab;

   public void BuildBase(List<Block> blocks, int layer_id){
        foreach(Block b in blocks)
            Instantiate(WallPrefab, new Vector3(b.x + this.transform.position.x, b.y + this.transform.position.y, 0), Quaternion.identity);

    }

}
