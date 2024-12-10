using BepInEx.Configuration;

namespace VenomousSpider;

public static class ConfigManager {
    public static ConfigEntry<int> venomChance = null!;
    public static ConfigEntry<float> venomDuration = null!;
    public static ConfigEntry<float> venomCooldown = null!;
    public static ConfigEntry<int> venomDamage = null!;

    internal static void Initialize(ConfigFile configFile) {
        venomChance = configFile.Bind("General", "Venom Chance", 33,
                                      new ConfigDescription("The chance for venom to apply", new AcceptableValueRange<int>(1, 100)));

        venomDuration = configFile.Bind("General", "Venom Duration", 8F,
                                        new ConfigDescription("The duration of the venom", new AcceptableValueRange<float>(3F, 12F)));

        venomCooldown = configFile.Bind("General", "Venom Cooldown", 1F,
                                        new ConfigDescription("The time between damage by venom", new AcceptableValueRange<float>(1F, 3F)));

        venomDamage = configFile.Bind("General", "Venom Damage", 5,
                                      new ConfigDescription("The amount of damage taken by the venom", new AcceptableValueRange<int>(1, 100)));
    }
}