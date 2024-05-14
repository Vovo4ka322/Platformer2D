using UnityEngine;

public interface IDamageble
{
    void TakeDamage(int damage);

    Transform GetTransform();
}
