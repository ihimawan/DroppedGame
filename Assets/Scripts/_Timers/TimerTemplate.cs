using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class TimerTemplate : MonoBehaviour {

	[SerializeField]
	protected GameObject Filler;

	[SerializeField]
	[Range(0,1)]
	protected float timeSpeed = 0.7f;

	public BlockManager blockManager;

	protected Image FillerImage;
	protected float fillValue;

	// Use this for initialization
	void Start () {
		TimerStart();
	}

	public void setBlockManager (BlockManager bm)
	{
		blockManager = bm;
		Debug.Log("Block manager is set to = " + blockManager);
	}

	protected void TimerStart(){
		BeginAction();
		FillerImage = Filler.GetComponent<Image>();
		RestartTimer ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		fillValue -= timeSpeed / 100;
		FillerImage.fillAmount = fillValue;

		if (fillValue < 0) {
			OnTimeOver ();
		}
	}

	public void RestartTimer ()
	{
		fillValue = FillerImage.fillAmount = 1f;
	}

	public virtual void OnTimeOver(){
		Destroy(gameObject);
		OverAction();
	}

	public abstract void BeginAction();
	public abstract void OverAction();

}
