using UnityEngine;
using UnityEngine.Rendering;

public class SpriteShadow: MonoBehaviour
{
	[SerializeField] ShadowCastingMode shadowMode;


#if UNITY_EDITOR
	void OnValidate()
	{
		var renderer = GetComponent<Renderer>();
		if (renderer) renderer.shadowCastingMode = shadowMode;
	}
#endif
}
