using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    private KnockBackTrigger _knockBackTrigger;

    [Header("Player Info")]
    [SerializeField] private PlayerHealth _playerHealth;



    private void Start()
    {
        _knockBackTrigger = GetComponent<KnockBackTrigger>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _knockBackTrigger.KnockBack(collision);
            Debug.Log("Player Hit");
            TakeDamage();
        }
    }
    private void TakeDamage()
    {
        _playerHealth.TakeDamage(2);
    }
    
}





