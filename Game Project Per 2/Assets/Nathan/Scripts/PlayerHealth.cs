using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    
    private bool _isDead;

    [Header("Player Health Settings")]
    [SerializeField] private float _maxHealth = 10.00f;
    [SerializeField] private float _health;

    [Header("Health Bar Settings")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameManagerScript _gameManager;
 
    void Start()
    {
        _maxHealth = _health;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
    void Update()
    {
        _healthBar.fillAmount = Mathf.Clamp(_health / _maxHealth, 0, 1);

        if (_health <= 0 && !_isDead)
        {
            _isDead = true;
            _gameManager.GameOver();
        }
    }
}
