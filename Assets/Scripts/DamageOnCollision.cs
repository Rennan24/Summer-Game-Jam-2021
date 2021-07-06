using UnityEngine;

public class DamageOnCollision: MonoBehaviour
{
	[SerializeField] int amount;
	[SerializeField] bool destroyOnCollision;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.TryGetComponent(out Health health))
			health.Damage(amount, Vector3.zero);

		if (destroyOnCollision)
			Destroy(gameObject);
	}
}
