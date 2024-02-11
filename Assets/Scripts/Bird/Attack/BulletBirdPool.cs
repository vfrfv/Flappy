using System.Collections.Generic;
using UnityEngine;

public class BulletBirdPool : MonoBehaviour
{
    [SerializeField] private GameObject _conteiner;
    [SerializeField] private int _capacity = 15;

    private List<BulletBird> _pool = new List<BulletBird>();

    protected void Inetialeze(BulletBird prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            BulletBird spawned = Instantiate(prefab, _conteiner.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out BulletBird bullet)
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

    protected BulletBird Ñreate(BulletBird prefab)
    {
        BulletBird spawned = Instantiate(prefab, _conteiner.transform);
        _pool.Add(spawned);

        return spawned;
    }
}
