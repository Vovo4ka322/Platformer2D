using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private const int Damage = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out HealthBar healthBar))
        {
            healthBar.TakeDamage();
        }
    }

    public int MakeDamage() => Damage;
}
