using System;
using UnityEngine;

public class GameManager: MonoSingleton<GameManager>
{
	[SerializeField] Vector2 playerBoundsOffset = new Vector2(-0.7f, 0);
	[SerializeField] Vector2 worldBoundsOffset  = new Vector2(1.0f, 0);

	public Rect PlayerBounds { get; private set; }
	public Rect WorldBounds { get; private set; }

#if UNITY_EDITOR
	void OnValidate()
	{
		PlayerBounds = CalculateBounds(playerBoundsOffset);
		WorldBounds  = CalculateBounds(worldBoundsOffset);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(PlayerBounds.center, PlayerBounds.size);
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(WorldBounds.center, WorldBounds.size);
	}
#endif

	void Start()
	{

	}

	public Rect CalculateBounds(Vector2 offset)
	{
		var bounds = CameraExt.CalculateWorldBounds();

		bounds.xMin -= offset.x;
		bounds.xMax += offset.x;
		bounds.yMin -= offset.y;
		bounds.yMax += offset.y;

		return bounds;
	}

	public static bool InsideWorld(Vector2 pos) => Inst.WorldBounds.Contains(pos);
}
