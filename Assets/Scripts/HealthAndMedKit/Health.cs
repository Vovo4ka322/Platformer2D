using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageble
{
    private int _maxValue = 100;
    private int _enemyDamage = 50;

    public event Action<int> Changed;

    [field: SerializeField] public int Value { get; private set; }

    public void Add(int amount)
    {
        if (Value != _maxValue)
        {
            Value += amount;
            Changed?.Invoke(Value);
        }
        else
        {
            Value = _maxValue;
        }
    }

    public void TakeDamage()
    {
        Value -= _enemyDamage;
        Changed?.Invoke(Value);

        if (Value <= 0)
        {
            Destroy(gameObject);

            Debug.Log("Игрок умер");
        }
    }

    public Transform GetTransform() => transform;
}
