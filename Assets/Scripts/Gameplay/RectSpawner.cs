using UnityEngine;

public class RectSpawner : MonoBehaviour
{
	[SerializeField] GameObject go;
	[SerializeField] Vector2 size;
	[SerializeField] float initialDelay = 0f;
	[SerializeField] float spawnDelay   = 1f;

	float delayTime;

#if UNITY_EDITOR
	[SerializeField] Color color = new Color(1, 1, 1, 1);

	void OnDrawGizmos()
	{
		var oldColor = Gizmos.color;
		Gizmos.DrawWireCube(transform.position, size);
		Gizmos.color = oldColor;
	}
#endif

	void Start()
	{
		delayTime = initialDelay;
	}

	void Update()
	{
		if (Time.time < delayTime)
			return;

		var pos = transform.position;
		var offset = new Vector2(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y));
		Instantiate(go, (Vector2) pos + (offset / 2), Quaternion.identity);

		delayTime = Time.time + spawnDelay;
	}
}
