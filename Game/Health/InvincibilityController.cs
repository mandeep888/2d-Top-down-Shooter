using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake(){
        _healthController = GetComponent<HealthController>();
    }
    public void StartInvincibility(float duration) {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration){
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(duration);
        _healthController.IsInvincible = false;
    }
}
