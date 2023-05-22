using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    private KnockBackTrigger knockBackTrigger;

    private void Start()
    {
        knockBackTrigger = GetComponent<KnockBackTrigger>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            knockBackTrigger.KnockBack(collision);
            Invoke("TakeDamage", .15f);
        }
    }

    private void TakeDamage()
    {
        playerHealth.TakeDamage(10);
    }
}
