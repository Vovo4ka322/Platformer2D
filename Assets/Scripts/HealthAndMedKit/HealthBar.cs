using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private const string Enemy = "Enemy";

    private int _maxValue = 100;
    private Weapon _weapon;

    public event Action<int> Changed;

    [field: SerializeField] public int Value { get; private set; }


    private void Awake()
    {
          _weapon = GetComponent<Weapon>();
    }

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
        Value -= 50;
        Changed?.Invoke(Value);

        if (Value <= 0)
        {
            Destroy(gameObject);

            Debug.Log("Игрок умер");
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == Enemy)
    //    {
    //        Value -= 50;

    //        if (Value <= 0)
    //            Destroy(gameObject);
    //    }
    //}
}
