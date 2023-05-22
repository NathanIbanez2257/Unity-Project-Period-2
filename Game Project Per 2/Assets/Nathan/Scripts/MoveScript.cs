using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _horizontal;
    private bool _grounded;
    private bool _isFacingRight = true;

    [Header("Ground For Player")]
    [SerializeField] private LayerMask _groundLayer;
    

    private Transform _center;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Transform _groundCheck;
    
    [Header("Player Settings")]
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpingPower = 18f;

    [Header("Knockback Settings")]
    
    [SerializeField] private float _knockBackVel = 8f;
    [SerializeField] private bool _knockedBack;
    [SerializeField] private float _knockedBackTime = 1f;

    [Header("Audio Setting")]
    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _groundCheck = GetComponent<Transform>();
        _center = GetComponent<Transform>();

    }
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (!_knockedBack)
        {
            _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        }
        else
        {
            var lerpedXVel = Mathf.Lerp(_rb.velocity.x, 0f, Time.deltaTime * 3);
            _rb.velocity = new Vector2(lerpedXVel,_rb.velocity.y);
        }

        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }
     
        _anim.SetBool("run", _horizontal != 0 && IsGrounded());
        _anim.SetBool("grounded", IsGrounded());

    }

  
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
           _isFacingRight = !_isFacingRight;
            Vector3 _localScale = transform.localScale;
            _localScale.x *= -1f;
            transform.localScale = _localScale;
        }
    }

    public void KnockBack(Transform t)
    {
        Vector3 dir = _center.position - t.position;
        _knockedBack = true;
        _rb.velocity = dir.normalized * _knockBackVel;

        _spriteRenderer.color = Color.red;
        StartCoroutine(FadeToWhite(_spriteRenderer));

        StartCoroutine(AntiKnockBack());
    }

    public IEnumerator FadeToWhite(SpriteRenderer _spriteRend)
    {
        while(_spriteRend.color != Color.white)
        {
            yield return null;
            _spriteRend.color = Color.Lerp(_spriteRend.color, Color.white, Time.deltaTime * 3);
        }
    }

    private IEnumerator AntiKnockBack()
    {
        yield return new WaitForSeconds(_knockedBackTime);
        _knockedBack = false;
    }

}
