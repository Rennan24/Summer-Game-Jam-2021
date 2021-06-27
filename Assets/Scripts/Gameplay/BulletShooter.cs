using UnityEngine;

public class BulletShooter: MonoBehaviour
{
	[SerializeField] Bullet bullet;
	[SerializeField] Vector2 direction;
	[SerializeField] float speed = 5f;
	[SerializeField] float delay = 1f;

	float delayTime;

	public void Shoot()
	{
		if (Time.time < delayTime)
			return;

		bullet.Spawn(transform.position, direction, speed);
		delayTime = Time.time + delay;
	}
}