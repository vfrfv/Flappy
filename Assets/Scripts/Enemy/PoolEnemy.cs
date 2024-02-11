using System.Collections.Generic;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _conteiner;

    private int _capacity = 3;

    private List<Enemy> _pool = new List<Enemy>();

    protected void Inetialeze(Enemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _conteiner.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Enemy enemy)
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].gameObject.activeSelf == false)
            {
                enemy = _pool[i];
                return true;
            }
        }

        enemy = null;
        return false;
    }
}
