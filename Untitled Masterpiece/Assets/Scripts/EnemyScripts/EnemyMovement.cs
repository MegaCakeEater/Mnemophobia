using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Vector3 _startPosition;
    public Vector3 _endPosition;
    Vector3 moveLeft = Vector3.left;
    public float movementSpeed;
    Grid grid;

    void Awake()
    {   
        grid = GetComponent<Grid>();
    }

    void FindPath(Vector3 startPosition, Vector3 endPosition)
    {
        Node startNode = grid.NodeFromWorldPoint(_startPosition);
        Node endNode = grid.NodeFromWorldPoint(_endPosition);

        /*
         * Open and closed set for explored and to be explored nodes
         */
        HashSet<Node> openSet = new HashSet<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);
        
        

    }
  
    
    // Use this for initialization
    void Start () {
        transform.position = _startPosition;
        Debug.Log(grid);
	}
	

	// Update is called once per frame
	void Update () {
       
	}
}
