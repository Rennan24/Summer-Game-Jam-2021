using System;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
	[SerializeField] float moveSpeed = 5f;
	[SerializeField] float moveSmoothing = 2f;
	[SerializeField] BulletShooter[] shooters;

	Vector2 move;

	[SerializeField] Health health;
	public Health Health => health;

#if UNITY_EDITOR
	void OnValidate()
	{
		if (!health) health = GetComponent<Health>();
	}
#endif

	void Update()
	{
		var dt = Time.deltaTime;

		move = Vector2.Lerp(move, InputManager.Movement, moveSmoothing * dt);

		var moveOffset = (Vector3) move * (moveSpeed * dt);
		transform.position = GameManager.Inst.PlayerBounds.ClampPosition(transform.position + moveOffset);

		if (InputManager.AttackDown)
		{
			foreach (var shooter in shooters)
				shooter.Shoot();
		}

		if (Input.GetKeyDown(KeyCode.F))
			health.Damage(1);

	}
}