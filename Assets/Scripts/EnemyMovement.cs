using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform[] _wayPoints;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] private float _moveSpeed;

    private int _currentPoint = 0;

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        if (transform.position.x == _wayPoints[_currentPoint].position.x)
            _currentPoint = (_currentPoint + 1) % _wayPoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentPoint].position, _moveSpeed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > _wayPoints[_currentPoint].position.x)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
