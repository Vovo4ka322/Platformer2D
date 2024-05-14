using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStealer : MonoBehaviour
{
    [SerializeField] private int _vampirismDuration = 6;
    [SerializeField] private Health _health;
    [SerializeField] private Transform _enemyChecker;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private float _vampirismRadious = 3f;

    private int _healthSteal = 5;

    public IEnumerator StealHealth(List<Enemy> enemies)
    {
        if (enemies == null)
            yield break;

        float second = 1f;

        WaitForSeconds oneSecond = new WaitForSeconds(second);

        Enemy enemy = enemies[0];

        for (int i = 0; i < _vampirismDuration; i++)
        {
            if (enemy.Health.CurrentHealth > 0)
            {
                _health.TakeHealing(_healthSteal);
                enemy.Health.TakeDamage(_healthSteal);

                yield return oneSecond;
            }
        }
    }

    public void UseAbility()
    {
        List<Enemy> targets = FindTargets();
        IEnumerator healthStealer = StealHealth(targets);

        StartCoroutine(healthStealer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_enemyChecker.position,_vampirismRadious);
    }

    public List<Enemy> FindTargets()
    {
        List<Enemy> enemies = new List<Enemy>();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_enemyChecker.position, _vampirismRadious, _enemy);

        if (colliders.Length == 0)
            return null;

        foreach (Collider2D enemy in colliders)
        {
            enemies.Add(enemy.GetComponent<Enemy>());
        }

        return enemies;
    }
}
