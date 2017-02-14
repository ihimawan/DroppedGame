using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseCollider : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.transform.tag == "Player") {
			col.transform.GetComponent<Player>().Lose();
		}
	}
}
