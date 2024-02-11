using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AttackEnemy : PoolBullets
{
    private const string AnimatorAttack = "Attack";

    [SerializeField] private BulletEnemy _prefabBulletEnemy;

    private Animator _animator;
    private float _elapsedTime = 0;
    private int _firingTimer = 3;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Initialize(_prefabBulletEnemy);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _firingTimer)
        {
            _elapsedTime = 0;

            if (TryGetObject(out BulletEnemy bullet))
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = gameObject.transform.position;

                _animator.SetTrigger(AnimatorAttack);
            }
        }
    }
}
