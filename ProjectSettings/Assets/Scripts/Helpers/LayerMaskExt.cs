using UnityEngine;

public static class LayerMaskExt
{
	public static bool HasLayer(this LayerMask mask, Component component)
		=> mask == (mask | (1 << component.gameObject.layer));

	public static bool HasLayer(this Component collider, LayerMask layer)
		=> (layer >> collider.gameObject.layer) == 1;
}