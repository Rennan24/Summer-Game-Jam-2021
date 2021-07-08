using DG.Tweening;
using UnityEngine;
using TMPro;

public class GameUIManager: MonoSingleton<GameUIManager>
{
	[SerializeField] TMP_Text scoreText;
	[SerializeField] float scoreTweenTime = 1f;
	
	[SerializeField] TMP_Text livesText;
	[SerializeField] float livesTweenTime = 1f;

	[SerializeField] RectTransform healthbar;
	[SerializeField] float healthbarTweenTime = 1f;

	private int _score;
	public int Score
	{
		get => _score;
		set {
			var prevScore = _score;
			_score = Mathf.Max(0, value);
			DOVirtual.Float(prevScore, _score, scoreTweenTime, value => {
				scoreText.text = $"{value:F0}";
			}).SetEase(Ease.OutSine);
		}
	}

	private int _lives = 3;
	public int Lives
{
		get => _lives;
		set {
			var prevLives = _lives;
			_lives = Mathf.Max(0, value);
			DOVirtual.Float(prevLives, _lives, livesTweenTime, value => {
				livesText.text = $"{value:F0}";
			}).SetEase(Ease.OutSine);
		}
	}

	Vector2 healthbarSize;
	Health playerHealth;

	void Start()
    {
	    var player = FindObjectOfType<PlayerController>();
	    playerHealth = player.Health;
	    playerHealth.Damaged += OnDamaged;

	    healthbarSize = healthbar.rect.size;
    }

	void OnDamaged(int amount, int curHealth, Vector3 hitPos)
	{
		var t = 1 - (curHealth / (float) playerHealth.MaxHealth);
		var width = healthbarSize.x * t;

		healthbar.DOSizeDelta(new Vector2(-width, 0), healthbarTweenTime).SetEase(Ease.OutSine);
	}
}
