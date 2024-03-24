using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] _wayPoints;
    [SerializeField] private float _moveSpeed;

    private int _currentPoint = 0;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x == _wayPoints[_currentPoint].position.x)
            _currentPoint = (_currentPoint + 1) % _wayPoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentPoint].position, _moveSpeed * Time.deltaTime);
    }
}
