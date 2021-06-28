using System;
using UnityEngine;

public class SinMovement: MonoBehaviour
{
	[SerializeField] float speed = 5f;
	[SerializeField] float frequency = 1f;
	[SerializeField] float amplitude = 1f;

	[SerializeField] bool lookTowards = true;

	float startY;

#if UNITY_EDITOR
	void OnValidate()
	{

	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		var sY = transform.position.y;

		var pos = transform.position;
		var oldPos = pos;
		const float timestep = 0.05f;
		for (float t = 0; t < 2; t += timestep)
		{
			pos.x += speed * timestep;
			pos.y = sY + Mathf.Sin(t * frequency) * amplitude;
			Gizmos.DrawLine(oldPos, pos);
			oldPos = pos;
		}
	}
#endif

	void Start()
	{
		startY = transform.position.y;
	}

	void Update()
	{
		var dt = Time.deltaTime;
		var pos = transform.position;
		pos.x += speed * dt;
		pos.y = startY + Mathf.Sin(Time.time * frequency) * amplitude;

		if (lookTowards)
		{
			var dir = (transform.position - pos).normalized;
			transform.rotation = Quaternion.LookRotation(Vector3.back, dir);
		}

		transform.position = pos;

	}
}
