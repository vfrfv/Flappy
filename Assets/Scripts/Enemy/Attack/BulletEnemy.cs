using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float _speed = 2;

    private Transform _parent;
    private int _damage = 1;

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            bird.ApplayDamage(_damage);
            gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent(out LeftBorder leftBorder))
        {
            gameObject.SetActive(false);
        }
    }
}
