using System.Collections.Generic;
using UnityEngine;

public class PoolBullets : MonoBehaviour
{
    private GameObject _container;

    private int _capacity = 14;
    private List<BulletEnemy> _pool = new List<BulletEnemy>();

    protected void Initialize(BulletEnemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            BulletEnemy spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out BulletEnemy bullet)
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].gameObject.activeSelf == false)
            {
                bullet = _pool[i];
                return true;
            }
        }

        bullet = null;
        return false;
    }

    public void InitializeContainer(GameObject container)
    {
        _container = container;
    }
}