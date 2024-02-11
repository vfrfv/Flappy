using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AttackBird : BulletBirdPool
{
    private const string AnimatorAttack = "Attack";

    [SerializeField] private BulletBird _prefabBulletBird;

    private Animator _animator;
    private float _delayedFiring = 1;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Inetialeze(_prefabBulletBird);

        _coroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool IsShooting = true;
        var delay = new WaitForSeconds(_delayedFiring);

        while (IsShooting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (TryGetObject(out BulletBird bullet) == true)
                {
                    bullet.gameObject.SetActive(true);
                    bullet.transform.position = gameObject.transform.position;

                    _animator.SetTrigger(AnimatorAttack);

                    yield return delay;
                }
                else
                {
                    Ñreate(_prefabBulletBird);
                }
            }

            yield return null;
        }
    }
}
