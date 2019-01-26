using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AirConsolerManager : MonoBehaviour
{
    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void OnMessage(int from, JToken data)
    {
        float dx = (float)data["info"]["dx"];
        float dy = (float)data["info"]["dy"];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
