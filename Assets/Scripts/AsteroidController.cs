using UnityEngine;

public class AsteroidController: MonoBehaviour
{
	[SerializeField] Vector2 startMoveVel;

	[SerializeField] GameObject splitPrefab;
	[SerializeField] float splitAngle;
	[SerializeField] int splitCount;

	[Header("References:")]
	[SerializeField] Health health;
	[SerializeField] Rigidbody2D body2D;


#if UNITY_EDITOR
	void OnValidate()
	{
		if (!health) health = GetComponent<Health>();
		if (!body2D) body2D = GetComponent<Rigidbody2D>();
	}
#endif

	void Start()
	{
		body2D.velocity = startMoveVel;
	}

	void OnCollisionEnter2D(Collision2D other) { }

	void Split()
	{
		for (int i = 0; i < splitCount; i++)
		{
			var pos = Random.insideUnitCircle;
			// var dir =
			var go = Instantiate(splitPrefab, pos, Quaternion.identity);
		}

		Destroy(gameObject);
	}
}