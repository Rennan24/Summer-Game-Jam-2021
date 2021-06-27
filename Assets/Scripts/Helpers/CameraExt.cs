using UnityEngine;

public static class CameraExt
{
	static Camera cachedCamera;
	public static Camera Camera {
		get {
			if (cachedCamera == null)
				cachedCamera = Camera.main;

			return cachedCamera;
		}
	}

	public static Vector2 ScreenToWorld(Vector3 point)
	{
		point.z = -Camera.transform.position.z;
		return Camera.ScreenToWorldPoint(point);
	}

	public static Vector2 GetMouseWorldPos()
	{
		var mousePos = Input.mousePosition;
		mousePos.z = -Camera.transform.position.z;
		return Camera.ScreenToWorldPoint(mousePos);
	}

	public static Vector2 CalculateExtents()
		=> CalculateExtents(Camera);

	public static Vector2 CalculateExtents(this Camera cam)
	{
		var vertical   = cam.orthographicSize;
		var horizontal = vertical * Screen.width / Screen.height;
		return new Vector2(horizontal, vertical);
	}

	public static Vector3 ClampPosition(this Rect bounds, Vector3 pos)
	{
		return new Vector3(
			Mathf.Clamp(pos.x, bounds.xMin, bounds.xMax),
			Mathf.Clamp(pos.y, bounds.yMin, bounds.yMax),
			pos.z);
	}

	public static Rect CalculateLocalBounds()
	{
		var extents = CalculateExtents();
		return new Rect(0, 0, extents.x * 2, extents.y * 2);
	}

	public static Rect CalculateWorldBounds()
	{
		var cameraPos = Camera.transform.position;
		var extents = CalculateExtents();

		return new Rect {
			x      = cameraPos.x - extents.x,
			y      = cameraPos.y - extents.y,
			width  = extents.x * 2,
			height = extents.y * 2,
		};
	}
}
