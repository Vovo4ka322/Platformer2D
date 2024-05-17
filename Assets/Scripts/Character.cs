using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public Health Health {  get; protected set; }

    private void OnEnable()
    {
        Health.Changed += OnHealthLost;
    }

    private void OnDisable()
    {
        Health.Changed -= OnHealthLost;
    }

    public void OnHealthLost(int value)
    {
        if (isDead)
        {
            Destroy(gameObject);
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

    private bool isDead => Health.CurrentHealth <= 0;
}
