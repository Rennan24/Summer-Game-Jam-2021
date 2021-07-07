using UnityEngine;

public class BulletShooter: Shooter
{
	[SerializeField] Bullet bullet;
	[SerializeField] Vector2 direction;
	[SerializeField] float speed = 5f;
	[SerializeField] float delay = 1f;

	float delayTime;

#if UNITY_EDITOR
	void OnDrawGizmosSelected()
	{
		Gizmos.DrawRay(transform.position, direction);
	}

	void OnValidate()
	{
		transform.localRotation = Quaternion.LookRotation(Vector3.forward, direction);
	}
#endif

	public override void Shoot()
	{
		if (Time.time < delayTime)
			return;

		bullet.Spawn(transform.position, direction.normalized, speed, transform.rotation);
		delayTime = Time.time + delay;
	}
}

public abstract class Shooter: MonoBehaviour
{
	public abstract void Shoot();
}