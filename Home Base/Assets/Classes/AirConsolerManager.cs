using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AirConsolerManager : MonoBehaviour
{

    List<int> player_ids = new List<int>();
    public CannonShoot redCannonShoot, blueCannonShoot;

    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
    }


    void OnConnect(int from)
    {
        Debug.Log("DEVICE ID "+from + " is connected");
        player_ids.Add(from);

        if(player_ids.Count == 2)
        {
            Debug.Log("STARTING");
            AirConsole.instance.SetActivePlayers(2);

        }
    }

    void OnMessage(int from, JToken data)
    {
      
        float dx = (float)data["dx"];
        float dy = (float)data["dy"];
        Debug.Log("dx:"+dx + " dy:" + dy);
        var player_id = AirConsole.instance.ConvertDeviceIdToPlayerNumber(from);
        if(player_id == 0)
        {
            redCannonShoot.Shoot(dx, dy, 9);
        }else if (player_id == 1)
        {
            blueCannonShoot.Shoot(dx, dy, 8);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
