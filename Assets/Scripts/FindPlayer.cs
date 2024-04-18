using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageble damageble))
            _enemyMovement.StartChasePlayer(damageble.GetTransform());     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageble damageble))
            _enemyMovement.StopChasePlayer();
    }
}
