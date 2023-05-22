using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float direction;
    private BoxCollider2D boxCollider;
    [SerializeField] private float speed;

    private bool hit;
    private float lifetime;


    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 1.25)
            gameObject.SetActive(false);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag  == "Enemy")
        {
            //spriteRenderer.color = Color.red;
            //StartCoroutine(FadeToWhite(GetComponent<ZombieHealth>().ZombieSprite()));

            hit = true;
            boxCollider.enabled = false;
            Deactivate();
    
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<ZombieHealth>().TakeDamage(1);
            collision.gameObject.GetComponent<ZombieHealth>().DamagedZombie();

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
