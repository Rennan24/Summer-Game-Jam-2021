using UnityEngine;

public abstract class MonoSingleton<T>: MonoBehaviour where T: MonoSingleton<T>
{
	private static T _inst;
	public static T Inst
	{
		set => _inst = value;
		get {
			if (_inst == null)
				_inst = FindObjectOfType<T>();

			return _inst;
		}
	}

	protected virtual void Awake()
	{
		if (_inst == null)
		{
			_inst = (T) this;
		}
		else if(_inst != this)
		{
			Debug.LogWarning($"Extra Singleton: {name}", gameObject);
			Destroy(gameObject);
		}
	}

	protected virtual void OnDestroy()
	{
		if (_inst == this)
			_inst = null;
	}
}