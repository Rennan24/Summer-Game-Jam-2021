using TMPro;
using UnityEngine;

public class ScoreManager: MonoSingleton<ScoreManager>
{
	private int _score;
	public int Score
	{
		get => _score;
		set {
			_score = Mathf.Max(0, value);
		}
	}

	[Header("References:")]
	[SerializeField] TextMeshProUGUI scoreText;
}
