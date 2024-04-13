using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController _healthController;
    private SpriteFlash _spriteFlash;

    private void Awake(){
        _healthController = GetComponent<HealthController>();
        _spriteFlash = GetComponent<SpriteFlash>();
    }
    public void StartInvincibility(float duration , Color flashColor , int numberOfFlashes) {
        StartCoroutine(InvincibilityCoroutine(duration,flashColor,numberOfFlashes));
    }

    private IEnumerator InvincibilityCoroutine(float duration , Color flashColor , int numberOfFlashes){
        _healthController.IsInvincible = true;
        yield return  _spriteFlash.FlashCouroutine(duration,flashColor,numberOfFlashes);
        _healthController.IsInvincible = false;
    }
}
