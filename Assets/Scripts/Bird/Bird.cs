using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public event Action<int> Changed;

    public int Health { get; private set; } = 5;

    private void Start()
    {
        Changed?.Invoke(Health);
    }

    public void ApplayDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            Changed?.Invoke(Health);
        }

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
