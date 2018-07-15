﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public float _movementSpeed = 5f;
	public float _jumpHeight = 2f;
	public float _groundDistance = 0.2f;
	public float _sprintSpeed = 5f;
	public TerrainCollider _ground;
	private Rigidbody _rigidbody;
	private Vector3 _inputs;
	private bool _isGrounded;

	void Start () {
		_isGrounded = true;
		_inputs = Vector3.zero;
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		_inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
		if (Input.GetButtonDown("Sprint"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, _sprintSpeed * new Vector3((Mathf.Log(1f / (Time.deltaTime * _rigidbody.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _rigidbody.drag + 1)) / -Time.deltaTime)));
            _rigidbody.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
    }


    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.rotation * _inputs * _movementSpeed * Time.fixedDeltaTime);
    }
		
	void OnCollisionEnter(Collision hit) {
		if(hit.collider == _ground) {
			_isGrounded = true;
		}
	}
	void OnCollisionExit(Collision hit) {
		if(hit.collider == _ground) {
			_isGrounded = false;
		}
	}

	
}