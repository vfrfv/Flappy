using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemuMover : MonoBehaviour
{
    private float _speed = 4;
    private Transform _way;
    private Transform[] _points;
    private int _currentPoint;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _way = _enemy.Way;
        _speed = _enemy.Speed;

        _points = new Transform[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
        {
            _points[i] = _way.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint == _points.Length)
                _currentPoint = 0;
        }
    }
}
