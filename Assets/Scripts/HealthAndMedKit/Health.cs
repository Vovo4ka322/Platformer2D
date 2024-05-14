using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Health : MonoBehaviour, IDamageble
{
    private int _maxValue = 100;
    private int _minValue = 1;

    public event Action<int> Changed;

    [field: SerializeField] public int CurrentHealth { get; private set; }

    public void TakeHealing(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, _minValue, _maxValue);
        Changed?.Invoke(CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxValue);
        Changed?.Invoke(CurrentHealth);
    }

    public void LoseHealth()
    {
        CurrentHealth = 0;
        Changed?.Invoke(CurrentHealth);
    }

    public Transform GetTransform() => transform;
}
