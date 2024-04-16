using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FindPlayer : MonoBehaviour
{
    private const string Player = "Player";

    [SerializeField] private EnemyMovement _enemyMovement;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Player)
            _enemyMovement.ChasePlayer();
        else
            _enemyMovement.Move();
    }
}
