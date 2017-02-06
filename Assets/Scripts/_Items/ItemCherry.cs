using UnityEngine;
using System.Collections;

public class ItemCherry : ItemTemplate {

	//the cherry item increments user score!
	public override void ItemAction ()
	{
		LevelState.IncrementScore();
//		Debug.Log("Cherry!");
	}
}
