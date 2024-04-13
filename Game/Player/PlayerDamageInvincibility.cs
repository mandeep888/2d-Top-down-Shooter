using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDamageInvincibility : MonoBehaviour
{
    [SerializeField]
    private float _invincibilityDuration;
    [SerializeField]
    private Color _flashColor;
[SerializeField]
    private int _numberOfFlashes;
    private InvincibilityController _invincibilityController;

    private void Awake(){
        _invincibilityController = GetComponent<InvincibilityController>();
    }
    public void StartInvincibility(){
        _invincibilityController.StartInvincibility(_invincibilityDuration , _flashColor,_numberOfFlashes);
    }
}
