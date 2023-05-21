using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public KnockBackTrigger knockBackTrigger;
    //public MoveScript playerMovement;


    // Start is called before the first frame update
 

    /*
     * private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(2);
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerMovement._KBCounter = playerMovement._KBTotalTime;

            //if (playerMovement._KBCounter >= 0)
            //{
            //    if (playerMovement._knockFromRight == true)
            //    {
            //        playerMovement._rb.AddForce(new Vector2(playerMovement._KBforce, playerMovement._KBforce / 6f), ForceMode2D.Impulse);
            //    }

            //    if (playerMovement._knockFromRight == false)
            //    {
            //        playerMovement._rb.AddForce(new Vector2(-playerMovement._KBforce, playerMovement._KBforce / 6f), ForceMode2D.Impulse);
            //    }
            //    playerMovement._KBCounter -= Time.deltaTime;
            //}
            knockBackTrigger.KnockBack(collision);
            Invoke("TakeDamage", .15f);


            //playerHealth.TakeDamage(10);

        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    playerHealth.TakeDamage(10);
    //}

    private void TakeDamage()
    {
        playerHealth.TakeDamage(10);
    }

    // Update is called once per frame

}
