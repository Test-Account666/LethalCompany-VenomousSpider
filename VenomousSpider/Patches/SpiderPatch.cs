using System;
using HarmonyLib;
using Object = UnityEngine.Object;
using Random = Unity.Mathematics.Random;

namespace VenomousSpider.Patches;

[HarmonyPatch(typeof(SandSpiderAI))]
public static class SpiderPatch {
    [HarmonyPatch(nameof(SandSpiderAI.HitPlayerClientRpc))]
    [HarmonyPostfix]
    public static void ApplyVenom(int playerId) {
        if (playerId < 0) return;

        if (playerId >= StartOfRound.Instance.allPlayerScripts.Length) return;

        var player = StartOfRound.Instance.allPlayerScripts[playerId];

        if (player != StartOfRound.Instance.localPlayerController) return;

        if (player.isPlayerDead || !player.isPlayerControlled || !player.AllowPlayerDeath()) return;

        var position = player.transform.position;

        var random = new Random((uint) ((DateTime.Now.Ticks & 0x0000FFFF) + position.x + position.y + position.z));

        var generatedChance = random.NextInt(0, 100) + 1;

        if (generatedChance > ConfigManager.venomChance.Value) return;

        var hasVenom = player.TryGetComponent<VenomBehavior>(out var venom);

        if (hasVenom) Object.Destroy(venom);

        player.gameObject.AddComponent<VenomBehavior>();
    }
}