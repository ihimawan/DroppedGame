using UnityEngine;
using System.Collections;

public abstract class ItemTemplate : MonoBehaviour {

	[SerializeField]
	private GameObject itemTimerPrefab;

	public GameObject ItemTaken ()
	{
//		Debug.Log ("item is taken.");
		ItemAction ();
		Destroy (gameObject);

		return itemTimerPrefab;
	}

	//what does the item do?
	public abstract void ItemAction();

}
