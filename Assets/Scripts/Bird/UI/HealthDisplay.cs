using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _textMeshPro;

    private void OnEnable()
    {
        _bird.Changed += OnHealthChandet;
    }

    private void OnDisable()
    {
        _bird.Changed -= OnHealthChandet;
    }

    private void OnHealthChandet(int health)
    {
        _textMeshPro.text = health.ToString();
    }
}
