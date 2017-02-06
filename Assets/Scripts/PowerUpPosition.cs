using UnityEngine;
using System.Collections;

public class PowerUpPosition : MonoBehaviour {

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
