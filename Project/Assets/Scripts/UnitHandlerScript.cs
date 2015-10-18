using UnityEngine;
using System.Collections;

public class UnitHandlerScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void createUnit(GameObject nodeA, GameObject nodeB, float speed)
	{
		// Set up the new sprite
		GameObject newUnit = new GameObject("unit");
		newUnit.AddComponent<SpriteRenderer>();
		MoveToPoint mover = newUnit.AddComponent<MoveToPoint>();
		newUnit.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Units/BU");
		newUnit.transform.position = nodeA.transform.position;
		mover.speed = speed;
		mover.targetObject = nodeB;
		mover.useObjectAsTarget = true;
		mover.startMoving();
	}
}