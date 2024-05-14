using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public Health Health {  get; protected set; }

    private void Start()
    {
        Health = GetComponent<Health>();
    }

    public void OnHealthLost(int value)
    {
        if (isDead)
        {
            Destroy(gameObject);

            Debug.Log("Объект умер");
        }
    }

    public void AddHealth(int value)
    {
        Health.TakeHealing(value);
    }

    public void RemoveHealth(int value)
    {
        Health.TakeDamage(value);
    }

    private void OnEnable()
    {
        Health.Changed += OnHealthLost;
    }

    private void OnDisable()
    {
        Health.Changed -= OnHealthLost;
    }

    private bool isDead => Health.CurrentHealth <= 0;
}
