using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealth;

    public bool IsInvincible{get;set;}
    public float RemainingHealthPrecentage{
        get{
            return _currentHealth/_maximumHealth;
        }
    }

    public UnityEvent OnDied;
    public UnityEvent OnDamage;

    public UnityEvent OnHealthChanged;
    public void TakeDamage(float  damageAmount) {
        if (_currentHealth == 0 || IsInvincible)
        {
            return;
        }
        _currentHealth -= damageAmount;
        OnHealthChanged.Invoke();
        if (_currentHealth<0)
        {
            _currentHealth = 0;          
        }
        if (_currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else{
            OnDamage.Invoke();
        }
    }
    public void AddHealth(float  amountToAdd) {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }
        _currentHealth -= amountToAdd;
        OnHealthChanged.Invoke();
        if (_currentHealth>0)
        {
            _currentHealth = _maximumHealth;          
        }
    }
}
