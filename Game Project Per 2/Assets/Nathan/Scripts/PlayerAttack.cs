using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float _attackCooldown;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private GameObject[] _bullets;

    private float cooldownTimer = Mathf.Infinity;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > _attackCooldown)
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        _bullets[FindBullet()].transform.position = _bulletPoint.position;
        _bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindBullet()
    {
        for (int i = 0; i < _bullets.Length; i++)
        {
            if (!_bullets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
