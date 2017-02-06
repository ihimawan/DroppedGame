using UnityEngine;
using System.Collections;

public class ItemOptions : MonoBehaviour {

	public GameObject[] itemOptions;

	[Range(1,10)]
	public int normalItemProbability = 5; 

	private float[] distribution;

	[SerializeField]
	private GameObject obtainedPowerUpsObject;


	void Start(){

		distribution = new float[itemOptions.Length];
		setItemDistribution(distribution);

	}

	public GameObject getRandomItemInstance (Transform parent)
	{
		int rand = RandFuncs.Sample(distribution, (float)(normalItemProbability + itemOptions.Length - 1));
		Vector3 position = new Vector3(parent.position.x, parent.position.y + 1, parent.position.z);
		GameObject resultingItem = (GameObject) Instantiate(itemOptions[rand], position,Quaternion.identity);

		resultingItem.transform.parent = parent;

		return resultingItem;
	}

	void setItemDistribution (float[] dist)
	{

		dist[0] = (float)normalItemProbability;
		for (int i = 1; i < dist.Length; i++) {
			dist[i] = 1f;
		}
		
	}

}
