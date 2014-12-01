using UnityEngine;
using System.Collections;


public static class EPPZEasing_Float_Extensions
{
	public static float ValueWithEasingType(this float this_, EPPZEasing.EasingType easingType)
	{ return EPPZEasing.EasingForType(easingType).ValueForInput(this_); }

	public static float ValueWithEasing(this float this_, EPPZEasing easing)
	{ return easing.ValueForInput(this_); }
}


public class EPPZEasing
{
	public enum EasingType
	{
		Linear,
		Ease_In,
		Ease_In_2,
		Ease_In_3,
		Ease_Out,
		Ease_Out_2,
		Ease_Out_3
	}

	private static EPPZEasing[] _easingPool = new EPPZEasing[]{
		new EPPZEasing_Linear(),
		new EPPZEasing_Ease_In(),
		new EPPZEasing_Ease_In_2(),
		new EPPZEasing_Ease_In_3(),
		new EPPZEasing_Ease_Out(),
		new EPPZEasing_Ease_Out_2(),
		new EPPZEasing_Ease_Out_3(),

	};

	public static EPPZEasing EasingForType(EasingType type)
	{ return _easingPool[(int)type]; }

	public virtual EasingType type { get { return 0; } }
	public virtual string name { get { return null; } }
	public virtual string description { get { return null; } }
	public virtual string algorithm { get { return null; } }
	public virtual float ValueForInput(float input) { return input; }
}


public class EPPZEasing_Linear : EPPZEasing
{
	public override EasingType type { get { return EasingType.Linear; } }
	public override string name { get { return "Linear"; } }
	public override string description { get { return "No easing"; } }
	public override string algorithm { get { return "y = x"; } }
	public override float ValueForInput(float input)
	{
		return input;
	}
}


public class EPPZEasing_Ease_In : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In; } }
	public override string name { get { return "Ease_in"; } }
	public override string description { get { return "Quadratic"; } } // Not "quartic"
	public override string algorithm { get { return "y = x^2"; } }
	public override float ValueForInput(float input)
	{
		return Mathf.Pow(input, 2.0f);
	}
}


public class EPPZEasing_Ease_In_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In; } }
	public override string name { get { return "Ease_in_2"; } }
	public override string description { get { return "Cubic"; } }
	public override string algorithm { get { return "y = x^3"; } }
	public override float ValueForInput(float input)
	{
		return Mathf.Pow(input, 3.0f);
	}
}


public class EPPZEasing_Ease_In_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In; } }
	public override string name { get { return "Ease_in_3"; } }
	public override string description { get { return "Octic"; } }
	public override string algorithm { get { return "y = x^8"; } }
	public override float ValueForInput(float input)
	{
		return Mathf.Pow(input, 8.0f);
	}
}


public class EPPZEasing_Ease_Out : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out; } }
	public override string name { get { return "Ease_out"; } }
	public override string description { get { return "Inverse quadratic"; } } // Not "quartic"
	public override string algorithm { get { return "y = 1 - (1-x)^2"; } }
	public override float ValueForInput(float input)
	{
		return 1.0f - Mathf.Pow(1.0f - input, 2.0f);
	}
}


public class EPPZEasing_Ease_Out_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out; } }
	public override string name { get { return "Ease_out_2"; } }
	public override string description { get { return "Inverse cubic"; } }
	public override string algorithm { get { return "y = 1 - (1-x)^3"; } }
	public override float ValueForInput(float input)
	{
		return 1.0f - Mathf.Pow(1.0f - input, 3.0f);
	}
}


public class EPPZEasing_Ease_Out_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out; } }
	public override string name { get { return "Ease_out_3"; } }
	public override string description { get { return "Inverse octic"; } }
	public override string algorithm { get { return "y = 1 - (1-x)^8"; } }
	public override float ValueForInput(float input)
	{
		return 1.0f - Mathf.Pow(1.0f - input, 8.0f);
	}
}

