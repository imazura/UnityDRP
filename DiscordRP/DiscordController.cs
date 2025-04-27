using Discord;
using System.Data;
using System.Globalization;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    public static DiscordController instance;
    public long applicationID = 1141719476669259877;
    [Space]
    public string details = "PlaceHolder";
    public string state = "Placeholder Numero Dos";
    [Space]
    public string largeImage = "ramen";
    public string largeText = "Yum, Ramen";

    private Rigidbody rb;
    private long time;

    private static bool instanceExists;
    public Discord.Discord discord;

    void Awake()
    {
        instance = this;
        if(!instanceExists)
        {
            instanceExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (FindObjectsOfType(GetType()).Length > 1)
        { 
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        discord = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();

        UpdateStatus();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        UpdateStatus();
    }

    public void UpdateStatus()
    {
        try
        {
            var activityManager = discord.GetActivityManager();
            var activity = new Discord.Activity
            {
                Details = details,
                State = state,
                Assets =
                {
                    LargeImage = largeImage,

                    LargeText = largeText,
                },
                Timestamps =
                {
                    Start = time
                }

            };

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok) Debug.LogWarning("Failed to Connesct to Discord");
            });
        }
        catch
        {
            Destroy(gameObject);
        }
    }
}
