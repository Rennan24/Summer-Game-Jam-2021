using JetBrains.Annotations;
using UnityEngine;

public static class Templates
{
	[SourceTemplate]
	[Macro(Target = "typename", Expression = "guessExpectedType()", Editable = -1)]
	public static void getcomp<T>(this T x) where T: Component
	{
		//$ if (!x) x = GetComponent<$typename$>();
	}

	[SourceTemplate]
	[Macro(Target = "typename", Expression = "guessExpectedType()", Editable = -1)]
	public static void getcompChild<T>(this T x) where T: Component
	{
		//$ if (!x) x = GetComponentInChildren<$typename$>();
	}

	[SourceTemplate]
	[Macro(Target = "typename", Expression = "guessExpectedType()", Editable = -1)]
	public static void getcompParent<T>(this T x) where T: Component
	{
		//$ if (!x) x = GetComponentInParent<$typename$>();
	}

	[SourceTemplate]
	[Macro(Target = "typename", Expression = "guessExpectedType()", Editable = -1)]
	public static void findObjectOfType<T>(this T x) where T: Component
	{
		//$ if (!x) x = FindObjectOfType<$typename$>();
	}

	// [SourceTemplate]
	// [Macro(Target = "typename", Expression = "guessExpectedType()", Editable = -1)]
	// public static void convertSystem<T>(T x) where T: Component
	// {
	// 	//$ Entities.ForEach(($typename$ comp) => AddHybridComponent(comp));
	// }
}
