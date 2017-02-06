using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public GameObject[] digits;
	public Sprite[] numberImages;

	private static int score;

	// Use this for initialization
	void Start () {
		for (int i = digits.Length-1; i >= 0; i++){
			
		}
		score = 0;
	}

	public static void IncrementScore(){
		score++;
		UpdateScoreUI();
	}

	static void UpdateScoreUI(){
		
		

	}




}
