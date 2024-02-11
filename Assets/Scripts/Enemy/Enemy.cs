using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action Died;

    public Transform Way { get; private set; }
    public int Speed { get; private set; }

    public void InitializeWay(Transform way) => Way = way;
    public void InitializeSpeed(int speed) => Speed = speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BulletBird bullet))
        {
            Die();
            Died?.Invoke();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
