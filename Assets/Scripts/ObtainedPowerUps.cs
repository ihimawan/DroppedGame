using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObtainedPowerUps : MonoBehaviour {

	[SerializeField]
	private BlockManager blockManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlacePowerUp (GameObject itemTimerPrefab)
	{
		
		if (itemTimerPrefab != null) {
			Transform nextSpot = NextAvailableSpot ();
			GameObject itemTimer = (GameObject)Instantiate (itemTimerPrefab, nextSpot.transform.position, Quaternion.identity);
			itemTimer.GetComponent<TimerTemplate>().setBlockManager(blockManager);
			itemTimer.transform.parent = nextSpot;
		}

	}

	Transform NextAvailableSpot ()
	{
		foreach (Transform child in transform) {
			if (child.childCount <= 0) {
				return child;
			}
		}

		return null;
	}
}
