using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour {

	public Camera _playerCam;
	public float _cameraSpeed;
	public float _cameraRestrictMax;
	public float _cameraRestrictMin;
	public Vector3 _cameraOffset;
	public float _smoothingX;
	public float _smoothingY;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion cameraAngle =  Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _cameraSpeed, Vector3.up);
		transform.rotation = transform.rotation * cameraAngle;
		_cameraOffset =  cameraAngle * _cameraOffset;
		Vector3 newPosition = transform.position + _cameraOffset;
		_playerCam.transform.position = Vector3.Slerp(transform.position,newPosition,_smoothingX);
		_playerCam.transform.rotation = transform.rotation * cameraAngle;
		_playerCam.transform.eulerAngles = new Vector3(Mathf.Clamp(-Input.mousePosition.y * _smoothingY, _cameraRestrictMin, _cameraRestrictMax), _playerCam.transform.eulerAngles.y, 0f);
	}
}
