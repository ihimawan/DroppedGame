using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelState : MonoBehaviour {

	private static int score;
	public static Text scoreText;

	static Animator anim; 

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		scoreText = GetComponent<Text>();
		score = 0;
		UpdateScoreUI ();
	}

	public static void IncrementScore(){
		score++;
		UpdateScoreUI ();
		anim.SetTrigger("updated");
		anim.SetTrigger("updated");
	}

	public static void UpdateScoreUI ()
	{
		scoreText.text = score.ToString();
	}


}
