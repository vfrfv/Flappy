using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackEnemy : PoolBullets
{
    private const string AnimatorAttack = "Attack";

    [SerializeField] private BulletEnemy _prefabBulletEnemy;

    private Animator _animator;
    private float _delayedFiring = 3;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Initialize(_prefabBulletEnemy);

        _coroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool IsShooting = true;
        var delay = new WaitForSeconds(_delayedFiring);

        while (IsShooting)
        {
            if (TryGetObject(out BulletEnemy bullet))
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = gameObject.transform.position;

                _animator.SetTrigger(AnimatorAttack);

                yield return delay;
            }

            yield return null;
        }
    }
}
