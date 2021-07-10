using System;
using UnityEngine;
using TMPro;

public class PlayAgain : MonoBehaviour
{
    public TMP_Text gameOver;
	public TMP_Text gameOverLabel;
    public int score;
    private static readonly string finalScore = "FinalScore";

    void Start(){
        score = PlayerPrefs.GetInt(finalScore);
    	gameOver = GameObject.Find("GameOver").GetComponent<TMP_Text>();
		gameOverLabel = GameObject.Find("GameOverLabel").GetComponent<TMP_Text>();
    	gameOverLabel.text = "Final Score";
		gameOver.text = $"{score}";
    }
}
