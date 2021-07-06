using System;
using UnityEngine;

public class Bullet: MonoBehaviour
{
	[SerializeField] Vector2 direction;
	[SerializeField] float speed;
	[SerializeField] int damage;
	[SerializeField] LayerMask mask;

	public Bullet Spawn(Vector3 pos, Vector2 dir, float speed)
	{
		var bullet = Instantiate(this, pos, transform.rotation);
		bullet.direction = dir;
		bullet.speed = speed;

		return bullet;
	}

	void Update()
	{
		var dt = Time.deltaTime;
		transform.position += (Vector3) direction * (speed * dt);

		if (!GameManager.InsideWorld(transform.position))
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.HasLayer(mask))
			return;

		if (other.TryGetComponent<Health>(out var health))
			health.Damage(damage);

		Destroy(gameObject);
	}

}
