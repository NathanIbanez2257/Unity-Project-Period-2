using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private float _closeRange = 25.00f, _midRange = 80.00f, _farRange = 194.00f, _farthestRange = 300.00f, _lastStage = 25f,
                  _moveSpeed;
    private bool _isFacingRight = true;
    [SerializeField] private bool _finalStage;
    private Rigidbody2D _rb;
    private bool soundCheck = false;
    private bool lastStageZombies = false;


    public string _zombieDistance;

    private bool _finalRange = false;
    [SerializeField] private bool _ZombieStatic;

    [Header("Player Component")]
    [SerializeField] private Transform _player;

    [SerializeField] private AudioSource _zombieSound;

    void Start()
    {
        _zombieSound = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float _distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        ChasePlayer();
        InFinalRange();

        if (_finalStage == false && !_ZombieStatic)
        {
            if (_distanceToPlayer < _closeRange)
            {
                ZombieSound();

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

        else if (_finalStage && !_ZombieStatic && !lastStageZombies)
        {
            _moveSpeed = 0;
            Debug.Log("Inside else if");

            if (_distanceToPlayer > _lastStage && !lastStageZombies)
            {
                Debug.Log("inside if statement");
                ZombieSound();
                _moveSpeed = 0f;
            }
            else
            {
                if (_distanceToPlayer > _lastStage || !lastStageZombies)
                {
                    lastStageZombies = true;

                    Debug.Log("inside if if statement");
                    _moveSpeed = 6f;
                }
                else
                {
                    Debug.Log("lol");
                }
            }
        }

        else
        {
            if (_distanceToPlayer < _closeRange)
            {
                ZombieSound();

                _moveSpeed = 4.25f;
            }
            else
            {
                _moveSpeed = 0;
            }
        }
    }

    private void ZombieSound()
    {
            if (!soundCheck)
            {
                soundCheck = true;
                Debug.Log("Sound Play");
                _zombieSound.Play();
            }
    }

 
  
    public void ZombieDistance()
    {
        float _distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (_finalStage == false && _ZombieStatic)
        {
            if (_distanceToPlayer < _closeRange)
            {
                _zombieDistance = "Close Range";
                //Debug.Log("Close Range");
            }

            else if (_distanceToPlayer > _farthestRange)
            {
                _zombieDistance = "Farthest Range";
                //Debug.Log("Farthest Range");
            }

            else if (_distanceToPlayer > _farRange)
            {
                _zombieDistance = "Far Range";
                //Debug.Log("Far Range");
            }

            else if (_distanceToPlayer > _midRange)
            {
                _zombieDistance = "Mid Range";
                //Debug.Log("Mid Range");
            }

            else
            {
                _zombieDistance = "Deadzone Range";
                //Debug.Log("Deadzone Range");
            }
        }
    }

    public bool InFinalRange()
    {
        float _distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (_distanceToPlayer < _lastStage)
        {
            _finalRange = true;
        }
        else
        {
            _finalRange = false;
        }

        return _finalRange;
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
