using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		Debug.Log("hit " + other);
		if(other.gameObject.tag == "PlayerWeapon") {
			Destroy(this.gameObject);
		}
	}
}
