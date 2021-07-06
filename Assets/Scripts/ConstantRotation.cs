using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
	[SerializeField] float rotationSpeed;
	[SerializeField] bool randomizeOnStart = true;

	void Start()
	{
		if (randomizeOnStart)
			transform.eulerAngles += new Vector3(0, 0, Random.Range(0, 360));
	}

	void Update()
	{
		transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
	}
}
