using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AttackBird : BulletBirdPool
{
    private const string AnimatorAttack = "Attack";

    [SerializeField] private BulletBird _prefabBulletBird;

    private Animator _animator;
    private float _lastFireTime;
    private float _firingTimer = 1;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Inetialeze(_prefabBulletBird);
    }

    private void Update()
    {
        if(Time.time - _lastFireTime >= _firingTimer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (TryGetObject(out BulletBird bullet) == true)
                {
                    bullet.gameObject.SetActive(true);
                    bullet.transform.position = gameObject.transform.position;

                    _animator.SetTrigger(AnimatorAttack);

                    _lastFireTime = Time.time;
                }
                else
                {
                    Ñreate(_prefabBulletBird);
                }
            }
        }   
    }
}
