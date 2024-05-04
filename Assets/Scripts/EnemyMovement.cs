using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    private Health _health;
    private int _currentPoint = 0;
    private bool _isPlayerFound;

    private void Awake()
    {
        _target = _wayPoints[_currentPoint];
    }

    private void Update()
    {
        if (_isPlayerFound == false)
        {
            if (transform.position.x == _wayPoints[_currentPoint].position.x)
            {
                _currentPoint = (_currentPoint + 1) % _wayPoints.Length;
                _target = _wayPoints[_currentPoint];
            }
        }

        MoveToTarget();
        TryFlip();
    }

    public void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
    }

    private void TryFlip() => _spriteRenderer.flipX = (transform.position.x > _target.position.x) == false;

    public void StartChasePlayer(Transform player)
    {
        _isPlayerFound = true;
        _target = player;
    }

    public void StopChasePlayer()
    {
        _isPlayerFound = false;
        _target = _wayPoints[_currentPoint];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            Destroy(gameObject);
        }
    }
}
