using UnityEngine;
using System.Collections;

public class CameraFollowUser : MonoBehaviour {

	public GameObject target;
	public float zdistance;
	public float ydistance;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, target.transform.position.y-ydistance, -zdistance);
	}
}
