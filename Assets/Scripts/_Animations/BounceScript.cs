using UnityEngine;
using System.Collections;

//the bounce of the blocks
public class BounceScript : MonoBehaviour {

	public float bounceHeight = 0.8f;
	public float bounceSpeed = 10f;

	private bool movingDown=false;
	private bool movingUp=false;
	private float bounceMoveLeft=0f;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}

	public void StartBouncing(){
		bounceMoveLeft = bounceHeight;
		movingDown=true; 
	}
	
	// Update is called once per frame
	void Update () {

		if (movingDown) { //if it needs to move down
			if (bounceMoveLeft > 0) { //if it has not gone through the bounce distance
				Vector3 oldPosition = transform.position;
				transform.position += Vector3.down * bounceSpeed * Time.deltaTime;
				bounceMoveLeft -= Vector3.Distance (oldPosition, transform.position);
			} else { //if it has gone through the bounce distance
				bounceMoveLeft = bounceHeight;
				movingDown=false;
				movingUp=true;
			}
		} else if (movingUp) { //if it needs to move up
			if (bounceMoveLeft > 0) { //if it has not gone through the bounce distance
				Vector3 oldPosition = transform.position;
				transform.position += Vector3.up * bounceSpeed * Time.deltaTime;
				bounceMoveLeft -= Vector3.Distance (oldPosition, transform.position);
			} else { //if it has gone through the bounce distance
				movingUp=false;
				bounceMoveLeft = 0;
//				transform.position = originalPosition;
			}
		}

	}
}
