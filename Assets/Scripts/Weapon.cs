using UnityEngine;

public class Weapon : MonoBehaviour
{
    private const int _damage = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamageble damageble))
        {
            damageble.TakeDamage(_damage);
        }
    }
}
