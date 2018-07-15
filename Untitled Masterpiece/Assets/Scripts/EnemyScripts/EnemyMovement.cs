using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Vector3 _startPosition;
    public Vector3 _endPosition;
    public float movementSpeed = 1.5f;

    //states needed are: PATROLLING, ALERTED, RETURNING -- SET UP STATEDIAGRAM IN DRAW.IO FOR EASE OF IMPLEMENTATION
    private bool justReachedEnd;
    private bool alerted;

	// Use this for initialization
	void Start () {
        transform.position = _startPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {



        /*
         * Code for handling patrolling, will set up statemachine for alerted state in which the player is spotted
         * needs a current position which it will remember and return to if alerted mode goes off
         */
        
		if(transform.position != _endPosition && !justReachedEnd)
        {
            //calculate vector distance between current and end position using a*
        }
        if(transform.position == _endPosition && !justReachedEnd)
        {
            justReachedEnd = true;
        }
        if(justReachedEnd && transform.position != _startPosition)
        {
            //calculate vector distance between current and start position using a* 
            //if possible just use same path as enemy came from but that might be a bit bad practice if the landscape changes
        }
        if(justReachedEnd && transform.position == _startPosition)
        {
            justReachedEnd = false;
        }
	}
}
