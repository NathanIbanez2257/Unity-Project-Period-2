using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   // public float projectileSpeed;

    // public GameObject impactEffect;
    private float direction;
    private BoxCollider2D boxCollider;

    private ZombieHealth zombieHealth;
    //[SerializeField] Rigidbody2D rb;
    [SerializeField] private float speed;

    private bool hit;
    private float lifetime;


    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //rb = GetComponent<Rigidbody2D>();

        // rigidBody.velocity = transform.right * projectileSpeed * direction;

    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 6)
            gameObject.SetActive(false);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag  == "Enemy")
        {
           // collision.gameObject.GetComponent<ZombieHealth>().TakeDamage(1);

            hit = true;
            boxCollider.enabled = false;
            Deactivate();
            /*
            if (collision.tag == "Enemy")
            {
                gameObject.SetActive(false);
            }
            */
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<ZombieHealth>().TakeDamage(1);
            //zombieHealth.TakeDamage(1);
        }
    }


    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);


    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
