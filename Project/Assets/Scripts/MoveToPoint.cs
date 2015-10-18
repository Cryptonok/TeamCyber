using UnityEngine;
using System.Collections;
using System;

public class MoveToPoint : MonoBehaviour {

    public float speed;
    public Vector3 targetPosition;
    public bool useObjectAsTarget;
    public GameObject targetObject;

    public bool isMoving;
    public bool destReached;

    /*
     * Call this method to send the object moving; assuming a targetPosition
     * or teargetObject has already been set. Alternatively, you can just set
     * the "isMoving" variable to true.
     */
    public void startMoving()
    {
        isMoving = true;
        destReached = false;
    }

    public void stopMoving()
    {
        isMoving = false;
    }

    public void destinationReached()
    {
		//Tell the node you reached it
		if(targetObject != null) {
			targetObject.GetComponent<myNodeScript>().unitHit();
		}
		//Despawn Unit
		GameObject.Destroy(gameObject);
    } 

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        //Check to see if a taget is set
        if ((targetPosition != null && !useObjectAsTarget) ||
            (targetObject != null && useObjectAsTarget))
        {
            if (isMoving && !destReached)
            {
                //Note: Only the x and y components of these vectors will be used
                Vector3 path;
                if (useObjectAsTarget)
                {
                    path = targetObject.GetComponent<Transform>().position - GetComponent<Transform>().position;
                }
                else
                {
                    path = targetPosition - GetComponent<Transform>().position;
                }
                Vector3 normalizedVector = path.normalized;

                //Path is complete, reach destination
                if (speed >= path.magnitude)
                {
                    GetComponent<Transform>().position += path;
                    destReached = true;
                    destinationReached();
                    isMoving = false;
                }
                //Path is incomplete, increment position by speed
                else
                {
                    GetComponent<Transform>().position += (normalizedVector * speed);
                }
				GetComponent<Transform>().rotation = Quaternion.FromToRotation(Vector3.left, path);
            }
        }
	}
}
