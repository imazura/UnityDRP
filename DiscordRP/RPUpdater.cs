using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPUpdater : MonoBehaviour
{
    public string details;
    public string state;
    public string image;
    public string text;
    void Start()
    {
        DiscordController.instance.details = details;
        DiscordController.instance.state = state;
        DiscordController.instance.largeImage = image;
        DiscordController.instance.largeText = text;

        DiscordController.instance.UpdateStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
