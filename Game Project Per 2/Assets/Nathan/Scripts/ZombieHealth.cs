using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private SpriteRenderer _spriteRend;
    [SerializeField] private ScoreScript _scoreScript;
    [Header("Health Setttings")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health = 5;

    private void Start()
    {
        _spriteRend = GetComponent<SpriteRenderer>();
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _scoreScript._scoreValue += 1;
            Destroy(gameObject);
        }
    }

    public void DamagedZombie()
    {
        StartCoroutine(FadeToWhite(_spriteRend));
    }

   
    public IEnumerator FadeToWhite(SpriteRenderer _spriteRend)
    {
        Debug.Log("FadeToWhite Ran");
        _spriteRend.color = Color.red;

        while (_spriteRend.color != Color.white)
        {
            yield return null;
            _spriteRend.color = Color.Lerp(_spriteRend.color, Color.white, Time.deltaTime * 1);
        }
    }


}
