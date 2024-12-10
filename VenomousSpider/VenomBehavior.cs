using System.Collections;
using UnityEngine;

namespace VenomousSpider;

public class VenomBehavior : MonoBehaviour {
    public float nextDamage = ConfigManager.venomCooldown.Value;

    private void Start() => StartCoroutine(DestroyAfterDelay(ConfigManager.venomDuration.Value));

    private void Update() {
        nextDamage -= Time.deltaTime;

        if (nextDamage > 0) return;

        nextDamage = ConfigManager.venomCooldown.Value;
        StartOfRound.Instance.localPlayerController.DamagePlayer(ConfigManager.venomDamage.Value, causeOfDeath: CauseOfDeathExtension.Venom);
    }

    public IEnumerator DestroyAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(this);
    }
}