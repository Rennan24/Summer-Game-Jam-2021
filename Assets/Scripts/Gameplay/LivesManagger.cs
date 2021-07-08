using TMPro;
using UnityEngine;

public class LivesManager: MonoSingleton<LivesManager>
{
	private int _lives;
	public int Lives
	{
		get => _lives;
		set {
			_lives = Mathf.Max(0, value);
			// scoreText.text = $"{Score}";
			// gameOver.text = $"Game Over! Your Score: {_score}";
		}
	}

	[Header("References:")]
	[SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gameOver;
}
