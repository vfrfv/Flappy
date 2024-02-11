using UnityEngine;

public class BulletBird : MonoBehaviour
{
    float _speed = 3;

    private void Update()
    {
        transform.Translate(-Vector3.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out RightBorder border))
        {
            gameObject.SetActive(false);
        }
    }
}
