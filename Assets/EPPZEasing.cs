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

		// Exponential

		Ease_In,
		Ease_In_2,
		Ease_In_3,

		Ease_Out,
		Ease_Out_2,
		Ease_Out_3,

		Ease_In_Out,
		Ease_In_Out_2,
		Ease_In_Out_3,

		// Circular
		
		Ease_In_Circular,
		Ease_Out_Circular,
		Ease_In_Out_Circular


	}

	private static EPPZEasing[] _easingPool = new EPPZEasing[]{
		new EPPZEasing_Linear(),
		new EPPZEasing_Ease_In(),
		new EPPZEasing_Ease_In_2(),
		new EPPZEasing_Ease_In_3(),
		new EPPZEasing_Ease_Out(),
		new EPPZEasing_Ease_Out_2(),
		new EPPZEasing_Ease_Out_3(),
		new EPPZEasing_Ease_In_Out(),
		new EPPZEasing_Ease_In_Out_2(),
		new EPPZEasing_Ease_In_Out_3(),
		new EPPZEasing_Ease_In_Circular(),
		new EPPZEasing_Ease_Out_Circular(),
		new EPPZEasing_Ease_In_Out_Circular()

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
	public override string algorithm { get { return "y = x"; } } // http://fooplot.com/plot/dnmxpux77q
	public override float ValueForInput(float input)
	{
		return input;
	}
}


public class EPPZEasing_Ease_In : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In; } }
	public override string name { get { return "Ease_In"; } }
	public override string description { get { return "Quadratic"; } }
	public override string algorithm { get { return "y = x^2"; } } // http://fooplot.com/plot/s30h4e1q70
	public override float ValueForInput(float input)
	{
		return Mathf.Pow(input, 2.0f);
	}
}


public class EPPZEasing_Ease_In_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_2; } }
	public override string name { get { return "Ease_In_2"; } }
	public override string description { get { return "Cubic"; } }
	public override string algorithm { get { return "y = x^3"; } } // http://fooplot.com/plot/98zyzpz4sk
	public override float ValueForInput(float input)
	{
		return Mathf.Pow(input, 3.0f);
	}
}


public class EPPZEasing_Ease_In_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_3; } }
	public override string name { get { return "Ease_In_3"; } }
	public override string description { get { return "Octic"; } }
	public override string algorithm { get { return "y = x^8"; } } // http://fooplot.com/plot/g3zxw2926b
	public override float ValueForInput(float input)
	{
		return Mathf.Pow(input, 8.0f);
	}
}


public class EPPZEasing_Ease_Out : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out; } }
	public override string name { get { return "Ease_Out"; } }
	public override string description { get { return "Inverse quadratic"; } }
	public override string algorithm { get { return "y = 1 - (1-x)^2"; } } // http://fooplot.com/plot/1nk2180aab
	public override float ValueForInput(float input)
	{
		return 1.0f - Mathf.Pow(1.0f - input, 2.0f);
	}
}


public class EPPZEasing_Ease_Out_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_2; } }
	public override string name { get { return "Ease_Out_2"; } }
	public override string description { get { return "Inverse cubic"; } }
	public override string algorithm { get { return "y = 1 - (1-x)^3"; } } // http://fooplot.com/plot/k8yltyv60y
	public override float ValueForInput(float input)
	{
		return 1.0f - Mathf.Pow(1.0f - input, 3.0f);
	}
}


public class EPPZEasing_Ease_Out_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_3; } }
	public override string name { get { return "Ease_Out_3"; } }
	public override string description { get { return "Inverse octic"; } }
	public override string algorithm { get { return "y = 1 - (1-x)^8"; } } // http://fooplot.com/plot/8xw4m0d7az
	public override float ValueForInput(float input)
	{
		return 1.0f - Mathf.Pow(1.0f - input, 8.0f);
	}
}


public class EPPZEasing_Ease_In_Out : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out; } }
	public override string name { get { return "Ease_In_Out"; } }
	public override string description { get { return "Shrink, offset In / Out"; } }
	public override string algorithm { get { return "y = (x < 0.5) ? (2x)^2 / 2 : 0.5 + (1 - (2(1-x))^2) / 2"; } } // http://fooplot.com/plot/n34po7bfzf
	public override float ValueForInput(float input)
	{
		return (input < 0.5f)
			? Mathf.Pow(input * 2.0f, 2.0f) / 2.0f
			: 0.5f + (1.0f - Mathf.Pow((1.0f - input) * 2.0f, 2.0f)) / 2.0f;
	}
}


public class EPPZEasing_Ease_In_Out_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_2; } }
	public override string name { get { return "Ease_In_Out_2"; } }
	public override string description { get { return "Shrink, offset In / Out"; } }
	public override string algorithm { get { return "y = (x < 0.5) ? (2x)^3 / 2 : 0.5 + (1 - (2(1-x))^3) / 2"; } } // http://fooplot.com/plot/thnn6y22rk
	public override float ValueForInput(float input)
	{
		return (input < 0.5f)
			? Mathf.Pow(input * 2.0f, 3.0f) / 2.0f
			: 0.5f + (1.0f - Mathf.Pow((1.0f - input) * 2.0f, 3.0f)) / 2.0f;
	}
}


public class EPPZEasing_Ease_In_Out_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_3; } }
	public override string name { get { return "Ease_In_Out_3"; } }
	public override string description { get { return "Shrink, offset In / Out"; } }
	public override string algorithm { get { return "y = (x < 0.5) ? (2x)^8 / 2 : 0.5 + (1 - (2(1-x))^8) / 2"; } } // http://fooplot.com/plot/1xu05v8kg4
	public override float ValueForInput(float input)
	{
		return (input < 0.5f)
			? Mathf.Pow(input * 2.0f, 8.0f) / 2.0f
			: 0.5f + (1.0f - Mathf.Pow((1.0f - input) * 2.0f, 8.0f)) / 2.0f;
	}
}


public class EPPZEasing_Ease_In_Circular : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Circular; } }
	public override string name { get { return "Ease_In_Circular"; } }
	public override string description { get { return "Inverse square root, inverse power"; } }
	public override string algorithm { get { return "y = 1 - sqrt(1 - x^2)"; } } // http://fooplot.com/plot/b0gv94068p
	public override float ValueForInput(float input)
	{
		return 1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(input, 2.0f));
	}
}


public class EPPZEasing_Ease_Out_Circular : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_Circular; } }
	public override string name { get { return "Ease_Out_Circular"; } }
	public override string description { get { return "Square root, power, inverse"; } }
	public override string algorithm { get { return "y = sqrt(1 - (1 - x)^2)"; } } // http://fooplot.com/plot/3dcodq0v9f
	public override float ValueForInput(float input)
	{
		return Mathf.Sqrt(1.0f - Mathf.Pow(1.0f - input, 2.0f));
	}
}


public class EPPZEasing_Ease_In_Out_Circular : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_Circular; } }
	public override string name { get { return "Ease_In_Out_Circular"; } }
	public override string description { get { return "Shrink, offset In / Out"; } }
	public override string algorithm { get { return "y = (x < 0.5) ? (1 - sqrt(1 - (2x)^2)) / 2 : 0.5 + sqrt(1 - ((2(1-x))^2)) / 2"; } } // http://fooplot.com/plot/e50chnjiq0
	public override float ValueForInput(float input)
	{
		return (input < 0.5f) 
			? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(input * 2.0f, 2.0f))) / 2.0f
			: 0.5f + Mathf.Sqrt(1.0f - Mathf.Pow((1.0f - input) * 2.0f, 2.0f)) / 2.0f;
	}
}