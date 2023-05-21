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

    [Header("Unity In Game Settings")]
    [SerializeField] public Rigidbody2D _rb;
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _groundCheck;
    

    [SerializeField] private LayerMask _groundLayer;

    [Header("Player Settings")]
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpingPower = 18f;

    [Header("Knockback Settings")]
    [SerializeField] private Transform _center;
    [SerializeField] private float _knockBackVel = 8f;
    [SerializeField] private bool _knockedBack;
    [SerializeField] private float _knockedBackTime = 1f;





    //[SerializeField] public float _KBforce;
    //[SerializeField] public float _KBCounter;
    //[SerializeField] public float _KBTotalTime;
    //[SerializeField] public bool _knockFromRight;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        //_horizontal = Input.GetAxisRaw("Horizontal");

        if (!_knockedBack)
        {
            _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        }
        else
        {
            var lerpedXVel = Mathf.Lerp(_rb.velocity.x, 0f, Time.deltaTime * 3);
            _rb.velocity = new Vector2(lerpedXVel,_rb.velocity.y);
        }


        //if (_KBCounter <= 0)
        //{

        //    _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        //}
        //else
        //{
        //    if (_knockFromRight == true)
        //    {
        //        _rb.AddForce(new Vector2(_KBforce, _KBforce / 6f), ForceMode2D.Impulse);
        //    }

        //    if (_knockFromRight == false)
        //    {
        //        _rb.AddForce(new Vector2(-_KBforce, _KBforce / 6f), ForceMode2D.Impulse);
        //    }
        //    _KBCounter -= Time.deltaTime;
        //}

        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0f)
        {
            Jump();
        }

        _anim.SetBool("run", _horizontal != 0 && IsGrounded());

        _anim.SetBool("grounded", IsGrounded());


    }


    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        IsGrounded();

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
        StartCoroutine(FadeToWhite());

        StartCoroutine(AntiKnockBack());
    }

    private IEnumerator FadeToWhite()
    {
        while(_spriteRenderer.color != Color.white)
        {
            yield return null;
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.white, Time.deltaTime * 3);
        }
    }

    private IEnumerator AntiKnockBack()
    {
        yield return new WaitForSeconds(_knockedBackTime);
        _knockedBack = false;
    }

}
