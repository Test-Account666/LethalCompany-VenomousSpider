using System.Linq;
using BepInEx.Bootstrap;

namespace VenomousSpider.Dependencies;

internal static class DependencyChecker {
    internal static bool IsLobbyCompatibilityInstalled() =>
        Chainloader.PluginInfos.Values.Any(metadata => metadata.Metadata.GUID.Contains("LobbyCompatibility"));
}