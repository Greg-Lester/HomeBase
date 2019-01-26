using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AirConsolerManager : MonoBehaviour
{

    List<int> player_ids = new List<int>();
    public CannonShoot redCannonShoot, blueCannonShoot;
    public BaseBuilder redBuilder, blueBuilder;

    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
    }

    struct GameMode
    {
        public string mode;
    }

    void OnConnect(int from)
    {
        Debug.Log("DEVICE ID "+from + " is connected");
        player_ids.Add(from);

        if(player_ids.Count == 2)
        {
            Debug.Log("STARTING");
            AirConsole.instance.SetActivePlayers(2);
            Screen.fullScreen = !Screen.fullScreen;
            var gm = new GameMode();
            gm.mode = "BUILDING";
            AirConsole.instance.Broadcast(gm);
        }
    }

    void OnMessage(int from, JToken data)
    {
        if ((string)data["action"] == "SHOOT")
        {
            float dx = (float)data["dx"];
            float dy = (float)data["dy"];
            Debug.Log("dx:" + dx + " dy:" + dy);
            var player_id = AirConsole.instance.ConvertDeviceIdToPlayerNumber(from);
            if (player_id == 0)
            {
                redCannonShoot.Shoot(dx, dy, 9);
            }
            else if (player_id == 1)
            {
                blueCannonShoot.Shoot(dx, dy, 8);
            }
        }
        if ((string)data["action"] == "BUILD")
        {
            IJEnumerable<JToken> components = data["components"].Children();
            List<Block> blocks = new List<Block>();
            var player_id = AirConsole.instance.ConvertDeviceIdToPlayerNumber(from);
            foreach (JToken comp in components)
            {
                float x = (int)comp["x"];
                float y = (int)comp["y"];
                x -= 161f;
                y -= 309f;
                x /= 40f;
                y /= 40f;
                y = -y;

                string type = (string)comp["type"];
                Debug.Log(x + ", " + y + ": " + type);
                blocks.Add(new Block(x, y));
            }
            if (player_id == 0)
            {
                redBuilder.BuildBase(blocks, 9);
            }
            else if (player_id == 1)
            {
                blueBuilder.BuildBase(blocks, 8);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
