using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	public Text scoreDisplay;
	public Text highScore;
	public static int score;
	public static int hiScore;
	// Use this for initialization
	void Start () {
		score = 0;

		SetScoreDisplay ();
		SetHighScoreDisplay ();
	}

//	void Update(){
//		SetScoreDisplay ();
//	}

	private void SetScoreDisplay()
	{
		scoreDisplay.text = "Score: " + score;
	}
	private void SetHighScoreDisplay()
	{
		
			highScore.text = "High Score: " + hiScore;


	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		SetScoreDisplay ();
	}


	// Update is called once per frame
	void Update () {
		if (score > hiScore) {
			hiScore = score;
			SetHighScoreDisplay ();
	}
	}
}
