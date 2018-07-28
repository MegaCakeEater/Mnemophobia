using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public float _movementSpeed = 5f;
    public float _jumpHeight = 2f;
    public float _sprintSpeed = 5f;
    private Rigidbody _rigidbody;
    private Vector3 _inputs;
    private bool _isGrounded;
    private Animator _animator;
    public BoxCollider _weaponCollider;
    public int _framesWeaponColliderActive = 20;
    private int _framesWeaponColliderActiveCounter = 0;
    private bool _attacking = false;

    void Start()
    {
        _isGrounded = true;
        _inputs = Vector3.zero;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        if (Input.GetButton("Sprint"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, _sprintSpeed * new Vector3((Mathf.Log(1f / (Time.deltaTime * _rigidbody.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _rigidbody.drag + 1)) / -Time.deltaTime)));
            _rigidbody.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
        if (Input.GetButton("Attack") && !_attacking)
        {
            _attacking = true;
			_animator.Play("PlayerWeaponAttack");
            _weaponCollider.enabled = true;
        }
    }


    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.rotation * _inputs * _movementSpeed * Time.fixedDeltaTime);
        if(_weaponCollider.enabled) {
            _framesWeaponColliderActiveCounter++;
        }
        if(_framesWeaponColliderActive <= _framesWeaponColliderActiveCounter) {
            _framesWeaponColliderActiveCounter = 0;
            _weaponCollider.enabled = false;
            _attacking = false;
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Terrain")
        {
            _isGrounded = true;
        }
    }
    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.tag == "Terrain")
        {
            _isGrounded = false;
        }
    }


}
