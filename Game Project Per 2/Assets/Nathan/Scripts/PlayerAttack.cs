using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;

    [SerializeField] private float attackCooldown;
    //[SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;



    private float cooldownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;
        Instantiate(projectile, firePosition.position, firePosition.rotation);

        //fireballs[0].transform.position = firePoint.position;
       // fireballs[0].GetComponent<Projectile>().SetDirection(Math.Sign(transform.localScale.x))


    }
}
