using System;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
	[SerializeField] float moveSpeed = 5f;
	[SerializeField] float moveSmoothing = 2f;
	[SerializeField] Shooter[] shooters;
	[SerializeField] Shooter[] Trigun;

	Vector2 move;

	[SerializeField] Health health;
	public Health Health => health;

	Shooter[] curShooters;

#if UNITY_EDITOR
	void OnValidate()
	{
		if (!health) health = GetComponent<Health>();
	}
#endif

	void Start()
	{
		curShooters = shooters;
	}

	void Update()
	{
		var dt = Time.deltaTime;

		move = Vector2.Lerp(move, InputManager.Movement, moveSmoothing * dt);

		var moveOffset = (Vector3) move * (moveSpeed * dt);
		transform.position = GameManager.Inst.PlayerBounds.ClampPosition(transform.position + moveOffset);

		if (InputManager.AttackDown)
		{
			foreach (var shooter in curShooters)
				shooter.Shoot();
		}

		if (Input.GetKeyDown(KeyCode.F))
			health.Damage(1);

		if (Input.GetKeyDown(KeyCode.Alpha1))
			curShooters = shooters;

		if (Input.GetKeyDown(KeyCode.Alpha2))
			curShooters = Trigun;
	}
}