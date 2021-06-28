using UnityEngine;

public class Health: MonoBehaviour
{
	public int MaxHealth     = 3;
	public float DamageDelay = 1f;
	public bool DestroyOnDeath = true;
	public int scoreValue = 100;

	public ScoreManager ScoreManager;

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

	private void Awake()
	{
		CurHealth = MaxHealth;
		ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

	}

	public void Damage(int amount, Vector3 hitPos = default)
	{
		if (Time.time < damageTime)
			return;

		damageTime = Time.time + DamageDelay;
		CurHealth -= amount;
		Damaged?.Invoke(amount, CurHealth, hitPos);

		if (CurHealth <= 0)
		{
			IsKilled = true;
			Killed?.Invoke(hitPos);

			if(DestroyOnDeath){
				ScoreManager.score += scoreValue;
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
