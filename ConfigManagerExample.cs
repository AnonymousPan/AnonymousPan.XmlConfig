using System;
using AnonymousPan.XmlConfig;

public class ConfigManagerExample : SimpleConfigManagerBase
{
    public ConfigEntryBool FullscreenMode { get; private set; }
    public ConfigEntryEnum<StringSplitOptions> EnumEntry { get; private set; }

    public ConfigEntryString UserName { get; private set; }
    public ConfigEntryInt32 UserID { get; private set; }

    public override void Initialize()
    {
        // General
        FullscreenMode = new ConfigEntryBool(ConfigFile, "General", "FullscreenMode", false,
            (val) => Console.WriteLine("Fullscreen mode: " + val.ToString()));
        EnumEntry = new ConfigEntryEnum<StringSplitOptions>(ConfigFile, "General", "EnumEntry",
            StringSplitOptions.None, null);

        // User
        UserName = new ConfigEntryString(ConfigFile, "User", "Name", "DefaultUser", null);
        UserID = new ConfigEntryInt32(ConfigFile, "User", "ID", 123456, null);
    }
}

/*
 * ==== Usage ====
 * Initialize:
 * ConfigManagerExample configManager = new ConfigManagerExample("AppConfig.xml");
 * configManager.Initialize();
 * 
 * Get value:
 * string val = configManager.UserName.Value;
 * 
 * Set value:
 * configManager.UserName.Value = "MyUser";
 * 
 * Save config:
 * configManager.Save();
 * 
 */
