using System.Collections;
using UnityEngine;

public class SpawnerEnemy : PoolEnemy
{
    [SerializeField] private GameObject _conteinerBullets;
    [SerializeField] private Enemy _enemuPrefab;
    [SerializeField] private Transform _way;
    [SerializeField] private bool _actiwe = true;

    private float _secondsBetweenSpawn = 3;
    private Coroutine _coroutine;
    private int _minSpeed = 1;
    private int _maxSpeed = 4;

    private void Start()
    {
        Inetialeze(_enemuPrefab);

        Revive();
    }

    private void Revive()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        var delay = new WaitForSeconds(_secondsBetweenSpawn);

        while (_actiwe)
        {
            int speed = Random.Range(_minSpeed, _maxSpeed);

            if (TryGetObject(out Enemy enemy) == false)
            {
                yield return delay;
                continue;
            }

            SetEnemy(enemy, gameObject.transform.position);

            enemy.InitializeWay(_way);
            enemy.InitializeSpeed(speed);
            enemy.GetComponent<AttackEnemy>().InitializeContainer(_conteinerBullets);

            yield return delay;
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
