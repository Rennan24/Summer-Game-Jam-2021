using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
	[SerializeField] Vector3 velocity;

	void Update()
	{
		transform.position += velocity * Time.deltaTime;
	}
}
