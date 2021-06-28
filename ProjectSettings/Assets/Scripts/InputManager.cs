using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager: MonoSingleton<InputManager>
{
	public static InputAction AttackAction => inputs.Player.Attack;

	public static Vector3 ScreenPoint { get; private set; }
	public static Vector3 Movement { get; private set; }
	public static float Horizontal { get; private set; }
	public static float Vertical { get; private set; }

	public static bool AttackDown { get; private set; }
	public static bool LeftClickDown { get; private set; }
	public static bool RightClickDown { get; private set; }

	static InputMap inputs;
	const float PressThreshold = 0.1f;

	void OnEnable() => inputs.Enable();
	void OnDisable() => inputs.Disable();

	protected override void Awake()
	{
		base.Awake();
		inputs = new InputMap();
	}

	void Update()
	{
		Movement   = inputs.Player.Move.ReadValue<Vector2>();
		Horizontal = Movement.x;
		Vertical   = Movement.y;

		ScreenPoint = inputs.UI.Point.ReadValue<Vector2>();

		AttackDown = inputs.Player.Attack.ReadValue<float>() > PressThreshold;

		LeftClickDown = inputs.UI.LeftClick.ReadValue<float>() > PressThreshold;
		RightClickDown = inputs.UI.RightClick.ReadValue<float>() > PressThreshold;
	}
}