using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public KnockBackTrigger knockBackTrigger;
    [Header("Zombie Damage")]
    [SerializeField] private int _damage;

    [Header("Player Info")]
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private MoveScript _playerMovement;


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            
            knockBackTrigger.KnockBack(collision);

            _playerHealth.TakeDamage(_damage);
        }
    }

   

