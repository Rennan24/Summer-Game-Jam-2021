using UnityEngine;

public class DestroyOnEnter: MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
