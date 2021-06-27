using System;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
	[SerializeField] float moveSpeed = 5f;
	[SerializeField] float moveSmoothing = 2f;
	[SerializeField] BulletShooter[] shooters;

	Vector2 move;

	public void Update()
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
	}
}
