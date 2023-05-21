using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private float _closeRange = 25.00f, _midRange = 80.00f, _farRange = 194.00f, _farthestRange = 300.00f, _moveSpeed;
    private bool _isFacingRight = true;
    private Rigidbody2D _rb;

    [Header("Player Component")]
    [SerializeField] private Transform _player;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float _distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        //Debug.Log("DistanceToPlayer" + distanceToPlayer);

        ChasePlayer();

        if (_distanceToPlayer < _closeRange)
        {
            _moveSpeed = 4.25f;
        }

        else if (_distanceToPlayer > _farthestRange)
        {
            _moveSpeed = 11f;
        }

        else if (_distanceToPlayer > _farRange)
        {
            _moveSpeed = 9f;
        }

        else if (_distanceToPlayer > _midRange)
        {
            _moveSpeed = 7f;
        }

        else
        {
            _moveSpeed = 3.5f;
        }
    }

    void ChasePlayer()
    {
        Vector3 _currentScale = gameObject.transform.localScale;

        if (transform.position.x < _player.position.x)
        {
            _rb.velocity = new Vector2(_moveSpeed, 0);    // move left
            transform.localScale = new Vector2(-.75f, .75f);
        }

        else if (transform.position.x > _player.position.x)
        {
            _rb.velocity = new Vector2(-_moveSpeed, 0);   // move right
            transform.localScale = new Vector2(.75f, .75f);
        }
    }

    void Flip()
    {
        Vector3 _currentScale = gameObject.transform.localScale;
        _currentScale.x *= -1;

        gameObject.transform.localScale = _currentScale;

        _isFacingRight = !_isFacingRight;
    }
}
