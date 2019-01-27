using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseBuilder : MonoBehaviour
{
    public GameObject Block2_1;
    public GameObject Block1_2;
    public GameObject Window2_1;
    public void onPlayerWin()
    {
        //TODO
    }
    public void BuildBase(List<Block> blocks, int layer_id){
        foreach(Block b in blocks)
        {
            GameObject prefab = null;
            if (b.type.Contains("window_2_1"))
            {
                prefab = Window2_1;
            }
            else if (b.type.Contains("block_1_2"))
            {
                prefab = Block1_2;
            }
            else if (prefab == null)
            {
                prefab = Block2_1;
            }
            var w = Instantiate(prefab, new Vector3(b.x + this.transform.position.x, b.y + this.transform.position.y, 0), Quaternion.identity);
            if (b.type.Contains("window"))
            {
                w.layer = layer_id;
            }
        }

    }

}
