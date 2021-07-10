using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health: MonoBehaviour
{
	public int MaxHealth     = 3;
	public float DamageDelay = 0;
	public bool DestroyOnDeath = false;
	public int scoreValue = 100;
	public int livesValue = 1;
	public TMP_Text livesText;
	Vector2 originalShipPos;
	GameObject go;
	Vector2 originalEnemyPos;
	private static readonly string finalScore = "FinalScore";

	[SerializeField]
	private int _curHealth;
	public int CurHealth
	{
		get => _curHealth;
		set => _curHealth = Mathf.Clamp(value, 0, MaxHealth);
	}

	public bool IsKilled { get; private set; }

	public delegate void OnDamaged(int amount, int curHealth, Vector3 hitPos);
	public delegate void OnHealed(int amount, int curHealth);
	public delegate void OnKilled(Vector3 hitPos);

	public event OnDamaged Damaged;
	public event OnKilled Killed;
	public event OnHealed Healed;

	float damageTime = -1f;

	void Start()
	{
		CurHealth = MaxHealth;
		Killed += pos => GameUIManager.Inst.Score += scoreValue;
		livesText = GameObject.Find("LivesText").GetComponent<TMP_Text>();
		originalShipPos = gameObject.transform.position;
		go = GameObject.Find("AsteroidSpawner");
		originalEnemyPos = go.transform.position;
	}

	public void Damage(int amount, Vector3 hitPos = default)
	{
		if (Time.time < damageTime)
			return;

		damageTime = Time.time + DamageDelay;
		CurHealth -= amount;
		Damaged?.Invoke(amount, CurHealth, hitPos);

		if (CurHealth <= 0 && !IsKilled)
		{
			IsKilled = false;
			Killed?.Invoke(hitPos);

			if (!DestroyOnDeath){
				GameUIManager.Inst.Lives -= livesValue;
				livesText.text = $"{GameUIManager.Inst.Lives}";
				CurHealth = MaxHealth;
				Damaged?.Invoke(amount, CurHealth, hitPos);
				gameObject.transform.position = originalShipPos;
				go.transform.position = originalEnemyPos;
				if (GameUIManager.Inst.Lives == 0){
					IsKilled = true;
					DestroyOnDeath = true;
					CurHealth = 0;
					Damaged?.Invoke(amount, CurHealth, hitPos);
					PlayerPrefs.SetInt(finalScore, GameUIManager.Inst.Score);
					SceneManager.LoadScene("PlayAgain");
				}
			}

			if (DestroyOnDeath){
				Destroy(gameObject);
			}
		}
	}

	public void Heal(int amount)
	{
		CurHealth += amount;
		Healed?.Invoke(amount, CurHealth);
	}
}
