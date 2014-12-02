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
		Ease_In_Out_Circular,

		// Bounce

		Ease_In_Bounce,
		Ease_In_Bounce_2,
		Ease_In_Bounce_3,

		Ease_Out_Bounce,
		Ease_Out_Bounce_2,
		Ease_Out_Bounce_3,
		
		Ease_In_Out_Bounce,
		Ease_In_Out_Bounce_2,
		Ease_In_Out_Bounce_3

	}

	private static EPPZEasing[] _easingPool = new EPPZEasing[]
	{
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
		new EPPZEasing_Ease_In_Out_Circular(),
		new EPPZEasing_Ease_In_Bounce(),
		new EPPZEasing_Ease_In_Bounce_2(),
		new EPPZEasing_Ease_In_Bounce_3(),
		new EPPZEasing_Ease_Out_Bounce(),
		new EPPZEasing_Ease_Out_Bounce_2(),
		new EPPZEasing_Ease_Out_Bounce_3(),
		new EPPZEasing_Ease_In_Out_Bounce(),
		new EPPZEasing_Ease_In_Out_Bounce_2(),
		new EPPZEasing_Ease_In_Out_Bounce_3()
	};

	public static EPPZEasing EasingForType(EasingType type)
	{ return _easingPool[(int)type]; }

	public virtual EasingType type { get { return 0; } }
	public virtual string name { get { return null; } }
	public virtual string description { get { return null; } }
	public virtual string algorithm { get { return null; } }
	public virtual string simplifiedAlgorithm { get { return algorithm; } }
	public virtual float ValueForInput(float x) { return x; }
}


public class EPPZEasing_Linear : EPPZEasing
{
	public override EasingType type { get { return EasingType.Linear; } }
	public override string name { get { return "Linear"; } }
	public override string description { get { return "No easing"; } }
	public override string algorithm { get { return "y = x"; } } // http://fooplot.com/plot/dnmxpux77q
	public override float ValueForInput(float x)
	{
		return x;
	}
}


public class EPPZEasing_Ease_In : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In; } }
	public override string name { get { return "Ease_In"; } }
	public override string description { get { return "Quadratic"; } }
	public override string algorithm { get { return "y = x^2"; } }
	public override float ValueForInput(float x)
	{
		return Mathf.Pow(x, 2);
	}
}


public class EPPZEasing_Ease_In_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_2; } }
	public override string name { get { return "Ease_In_2"; } }
	public override string description { get { return "Cubic"; } }
	public override string algorithm { get { return "y = x^3"; } }
	public override float ValueForInput(float x)
	{
		return Mathf.Pow(x, 3);
	}
}


public class EPPZEasing_Ease_In_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_3; } }
	public override string name { get { return "Ease_In_3"; } }
	public override string description { get { return "Octic"; } }
	public override string algorithm { get { return "y = x^8"; } }
	public override float ValueForInput(float x)
	{
		return Mathf.Pow(x, 8);
	}
}


public class EPPZEasing_Ease_Out : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out; } }
	public override string name { get { return "Ease_Out"; } }
	public override string description { get { return "Inverse quadratic"; } }
	public override string algorithm { get { return "y = 1-(1-x)^2"; } }
	public override float ValueForInput(float x)
	{
		return 1 - Mathf.Pow(1 - x, 2);
	}
}


public class EPPZEasing_Ease_Out_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_2; } }
	public override string name { get { return "Ease_Out_2"; } }
	public override string description { get { return "Inverse cubic"; } }
	public override string algorithm { get { return "y = 1-(1-x)^3"; } }
	public override float ValueForInput(float x)
	{
		return 2 * x - Mathf.Pow(x, 2);
	}
}


public class EPPZEasing_Ease_Out_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_3; } }
	public override string name { get { return "Ease_Out_3"; } }
	public override string description { get { return "Inverse octic"; } }
	public override string algorithm { get { return "y = 1-(1-x)^8"; } }
	public override float ValueForInput(float x)
	{
		return 1 - Mathf.Pow(1 - x, 8);
	}
}


public class EPPZEasing_Ease_In_Out : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out; } }
	public override string name { get { return "Ease_In_Out"; } }
	public override string description { get { return "Shrink, offset, simplify In / Out"; } }
	public override string algorithm { get { return "y = (x<0.5) ? (2x)^2/2 : 0.5+(1-(2(1-x))^2)/2"; } }
	public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 2x^2 : -2x^2+4x-1"; } }
	public override float ValueForInput(float x)
	{
		return (x < 0.5f)
			? 2 * Mathf.Pow(x, 2)
			: -2 * Mathf.Pow(x, 2) + 4 * x - 1;
	}
}


public class EPPZEasing_Ease_In_Out_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_2; } }
	public override string name { get { return "Ease_In_Out_2"; } }
	public override string description { get { return "Shrink, offset, simplify In / Out"; } }
	public override string algorithm { get { return "y = (x<0.5) ? (2x)^3/2 : 0.5+(1-(2(1-x))^3)/2"; } }
	public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 4x^3 : 4x^3-12x^2+12x-3"; } }
	public override float ValueForInput(float x)
	{
		return (x < 0.5f)
			? 4 * Mathf.Pow(x, 3)
			: 4 * Mathf.Pow(x, 3) - 12 * Mathf.Pow(x, 2) + 12 * x - 3;
	}
}


public class EPPZEasing_Ease_In_Out_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_3; } }
	public override string name { get { return "Ease_In_Out_3"; } }
	public override string description { get { return "Shrink, offset, simplify In / Out"; } }
	public override string algorithm { get { return "y = (x<0.5) ? (2x)^8/2 : 0.5+(1-(2(1-x))^8)/2"; } }
	public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 128x^8 : 0.5+(1-(2(1-x))^8)/2"; } }
	public override float ValueForInput(float x)
	{
		return (x < 0.5f)
			? 128 * Mathf.Pow(x, 8)
			: 0.5f + (1 - Mathf.Pow((1 - x) * 2, 8)) / 2;
	}
}


public class EPPZEasing_Ease_In_Circular : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Circular; } }
	public override string name { get { return "Ease_In_Circular"; } }
	public override string description { get { return "Inverse square root, inverse power"; } }
	public override string algorithm { get { return "y = 1-sqrt(1-x^2)"; } }
	public override float ValueForInput(float x)
	{
		return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
	}
}


public class EPPZEasing_Ease_Out_Circular : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_Circular; } }
	public override string name { get { return "Ease_Out_Circular"; } }
	public override string description { get { return "Square root, power, inverse"; } }
	public override string algorithm { get { return "y = sqrt(1-(1-x)^2)"; } }
	public override string simplifiedAlgorithm { get { return "y = sqrt(-(x-2)x)"; } }
	public override float ValueForInput(float x)
	{
		return Mathf.Sqrt(-(x - 2) * x);
	}
}


public class EPPZEasing_Ease_In_Out_Circular : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_Circular; } }
	public override string name { get { return "Ease_In_Out_Circular"; } }
	public override string description { get { return "Shrink, offset, simplify In / Out"; } }
	public override string algorithm { get { return "y = (x<0.5) ? (1-sqrt(1-(2x)^2))/2 : 0.5+sqrt(1-((2(1-x))^2))/2"; } }
	public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 0.5(1-sqrt(1-4x^2)) : 0.5(sqrt(-4(x-2)x-3)+1)"; } }
	public override float ValueForInput(float x)
	{
		return (x < 0.5f) 
			? 0.5f * (1 - Mathf.Sqrt(1 - 4 * Mathf.Pow(x, 2)))
			: 0.5f * (Mathf.Sqrt(-4 * (x - 2) * x - 3) + 1);
	}
}


public class EPPZEasing_Ease_In_Bounce : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Bounce; } }
	public override string name { get { return "Ease_In_Bounce"; } }
	public override string description { get { return "Offset power composition"; } }
	public override string algorithm { get { return "y = 2x^3-x^2"; } }
	public override string simplifiedAlgorithm { get { return "y = x^2(2x-1)"; } }
	public override float ValueForInput(float x)
	{
		return Mathf.Pow(x, 2) * (2 * x - 1);
	}
}


public class EPPZEasing_Ease_In_Bounce_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Bounce_2; } }
	public override string name { get { return "Ease_In_Bounce_2"; } }
	public override string description { get { return "Offset power composition"; } }
	public override string algorithm { get { return "y = 3x^3-2x^2"; } }
	public override string simplifiedAlgorithm { get { return "y = x^2(3x-2)"; } }
	public override float ValueForInput(float x)
	{
		return Mathf.Pow(x, 2) * (3 * x - 2);
	}
}


public class EPPZEasing_Ease_In_Bounce_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Bounce_3; } }
	public override string name { get { return "Ease_In_Bounce_3"; } }
	public override string description { get { return "Offset power composition"; } }
	public override string algorithm { get { return "y = 4x^3-3x^2"; } }
	public override string simplifiedAlgorithm { get { return "y = x^2(4x-3)"; } }
	public override float ValueForInput(float x)
	{
		return Mathf.Pow(x, 2) * (4 * x - 3);
	}
}


public class EPPZEasing_Ease_Out_Bounce : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_Bounce; } }
	public override string name { get { return "Ease_Out_Bounce"; } }
	public override string description { get { return "Inverse offset power composition"; } }
	public override string algorithm { get { return "y = 1-(2(1-x)^3-(1-x)^2)"; } }
	public override string simplifiedAlgorithm { get { return "y = x(x(2x-5)+4)"; } }
	public override float ValueForInput(float x)
	{
		return x * ( x * (2 * x - 5 ) + 4);
	}
}

public class EPPZEasing_Ease_Out_Bounce_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_Bounce_2; } }
	public override string name { get { return "Ease_Out_Bounce_2"; } }
	public override string description { get { return "Inverse offfset power composition"; } }
	public override string algorithm { get { return "y = 1-(3(1-x)^3-2(1-x)^2)"; } }
	public override string simplifiedAlgorithm { get { return "y = x(x(3x-7)+5)"; } }
	public override float ValueForInput(float x)
	{
		return x * ( x * (3 * x - 7 ) + 5);
	}
}


public class EPPZEasing_Ease_Out_Bounce_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_Bounce_3; } }
	public override string name { get { return "Ease_Out_Bounce_3"; } }
	public override string description { get { return "Inverse offset power composition"; } }
	public override string algorithm { get { return "y = 1-(4(1-x)^3-3(1-x)^2)"; } }
	public override string simplifiedAlgorithm { get { return "y = x(x(4x-9)+6)"; } }
	public override float ValueForInput(float x)
	{
		return x * ( x * (4 * x - 9 ) + 6);
	}
}


public class EPPZEasing_Ease_In_Out_Bounce : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_Bounce; } }
	public override string name { get { return "Ease_In_Out_Bounce"; } }
	public override string description { get { return "Shrink, offset, simplify In / Out"; } }
	public override string algorithm { get { return "y = (x<0.5) ? (2(2x)^3-(2x)^2)*0.5 : 1-(2(2(1-x))^3-(2(1-x))^2)*0.5"; } }
	public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 8x^3-2x^2 : 8x^3-22x^2+20x-5"; } }
	public override float ValueForInput(float x)
	{
		return (x < 0.5f) 
			? 8 * Mathf.Pow(x, 3) - 2 * Mathf.Pow(x, 2)
			: 8 * Mathf.Pow(x, 3) - 22 * Mathf.Pow(x, 2) + 20 * x - 5;
	}
}


public class EPPZEasing_Ease_In_Out_Bounce_2 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_Bounce_2; } }
	public override string name { get { return "Ease_In_Out_Bounce_2"; } }
	public override string description { get { return "Shrink, offset, simplify In / Out"; } }
	public override string algorithm { get { return "y = (x<0.5) ? (3(2x)^3- (2x)^2)*0.5 : 1-(3(2(1-x))^3-2(2(1-x))^2)*0.5"; } }
	public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 12x^3-4x^2 : 12x^3-32x^2+28x-7"; } }
	public override float ValueForInput(float x)
	{
		return (x < 0.5f) 
			? 12 * Mathf.Pow(x, 3) - 4 * Mathf.Pow(x, 2)
			: 12 * Mathf.Pow(x, 3) - 32 * Mathf.Pow(x, 2) + 28 * x - 7;
	}
}


public class EPPZEasing_Ease_In_Out_Bounce_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_In_Out_Bounce_3; } }
	public override string name { get { return "Ease_In_Out_Bounce_3"; } }
	public override string description { get { return "Shrink, offset In / Out"; } }
	public override string algorithm { get { return "y = ((x<0.5) ? (4(2x)^3-3(2x)^2)*0.5 : 1-(4(2(1-x))^3-3(2(1-x))^2)*0.5"; } }
	public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 16x^3-6x^2 : 16x^3-42x^2+36x-9"; } }
	public override float ValueForInput(float x)
	{
		return (x < 0.5f) 
			? 16 * Mathf.Pow(x, 3) - 6 * Mathf.Pow(x, 2)
			: 16 * Mathf.Pow(x, 3) - 42 * Mathf.Pow(x, 2) + 36 * x - 9;
	}
}

