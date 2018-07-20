using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Vector3 _startPosition;
    public Vector3 _endPosition;
    Vector3 moveLeft = Vector3.left;
    public float movementSpeed;
    NodeGrid grid;
    GameObject gridObject;
    bool printed = false;

    void Awake()
    {
        gridObject = GameObject.Find("A*");
        grid = gridObject.GetComponent<NodeGrid>();
        Debug.Log(grid);
    }

    void FindPath(Vector3 startPosition, Vector3 endPosition)
    {
        Node startNode = grid.NodeFromWorldPoint(startPosition);
        Node endNode = grid.NodeFromWorldPoint(endPosition);

        /*
         * Open and closed set for explored and to be explored nodes
         */
        HashSet<Node> openSet = new HashSet<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        
        foreach (Node n in grid.getNodes())
        {
            if (n.walkable)
            {
                n.SetHCost(_endPosition);
                openSet.Add(n);
            }
            
        }
        if (!printed)
        {
            Debug.Log(openSet.Count);
            printed = true;
        }
    }
  
    
    // Use this for initialization
    void Start () {
        transform.position = _startPosition;
        FindPath(_startPosition, _endPosition);
	}
	

	// Update is called once per frame
	void Update () {
        
    }
}
