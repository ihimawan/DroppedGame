using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour {

	private static int score;
	public static Text scoreText;

	static Animator anim; 

	// Use this for initialization
	void Start () {

		
		anim = GetComponent<Animator>();
		scoreText = GetComponent<Text>();

		if (SceneManager.GetActiveScene().name == "02 Game"){
			score = 0;
		}

		UpdateScoreUI ();
	}

	public static void IncrementScore(){
		score++;
		UpdateScoreUI ();
		anim.SetTrigger("updated");
	}

	public static void UpdateScoreUI ()
	{
		scoreText.text = score.ToString();
		Debug.Log("score is updated");
	}


}
