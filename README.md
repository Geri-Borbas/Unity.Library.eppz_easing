EPPZEasing
----------

The very essence of easing algorithms. All the easing algorithms here are intended for any use, regardless of time or any given values to change. **It only takes a (mostly linear / normalized) input, then spits out an eased output.**

As of above, you can use these algorithms for various reasons, manipulating image, blend forces, adjust volume, or as people do most of the time, you can ease animation keyframes as well of course. 


#### Simplicity

The code for EPPZEasing.Linear goes like:
```C#
return input; // :)
```

Compared to the usual easing implementations, like:
```C#
return valueChange * currentTime / duration + startValue;
```

While this is all fine above, it feels way too specific for me, as beside easing, it implements value changing over time, also forces you to normalize time in this manner. If you want to change 6 values at once, you have to ease each an every value.

Or you can compare EPPZEasing.Ease_In_3...
```C#
return Mathf.Pow(input, 3.0f);
```

...with the usual cubic easing implementation:
```C#
currentTime /= duration;
return valueChange * currentTime * currentTime * currentTime + startValue;
```

So once you have a linear completion (or any kind of) percentage somewhere in your code, you can just ease it as you like (see Usage below), then go along with the rest of the application.


#### Usage

Can be applied to any `float` using extension methods.
```C#
float easedCompletion = completion.ValueWithEasingType(EasingType.Ease_In_Out_Bounce_3);
```

Or you can use easing instances directly.
```C#
float easedCompletion = currentEasing.ValueForInput(completion);
```

Easing objects gets allocated once, then pooled at runtime. You can access them using static accessor.
```
EPPZEasing currentEasing = EPPZEasing.EasingForType(EasingType.Ease_In_Out_Circular);
```


#### Documentation

The code is mostly self documented, you can see actual easing algorithms with some explanations within the class bodies.

```C#
public class EPPZEasing_Ease_Out_Bounce_3 : EPPZEasing
{
	public override EasingType type { get { return EasingType.Ease_Out_Bounce_3; } }
	public override string name { get { return "Ease_Out_Bounce_3"; } }
	public override string description { get { return "Inverse offset power composition"; } }
	public override string algorithm { get { return "y = 1 - (4(1 - x)^3 - 3(1 - x)^2)"; } }
	public override string simplifiedAlgorithm { get { return "y = x(x(4x-9)+6)"; } }
	public override float ValueForInput(float x)
	{
		return x * ( x * (4 * x - 9 ) + 6);
	}
}
```


#### Algorithms

For easy reference, find the equations (and simplifications) implemented so far below.

```C#
// Linear
y = x

// Ease_In
y = x^2

// Ease_In_2
y = x^3

// Ease_In_3
y = x^8

// Ease_Out
y = 1-(1-x)^2

// Ease_Out_2
y = 1-(1-x)^3

// Ease_Out_3
y = 1-(1-x)^8

// Ease_In_Out
y = (x<0.5) ? (2x)^2/2 : 0.5+(1-(2(1-x))^2)/2
y = (x<0.5) ? 2x^2 : -2x^2+4x-1

// Ease_In_Out_2
y = (x<0.5) ? (2x)^3/2 : 0.5+(1-(2(1-x))^3)/2
y = (x<0.5) ? 4x^3 : 4x^3-12x^2+12x-3

// Ease_In_Out_3
y = (x<0.5) ? (2x)^8/2 : 0.5+(1-(2(1-x))^8)/2
y = (x<0.5) ? 128x^8 : 0.5+(1-(2(1-x))^8)/2

// Ease_In_Circular
y = 1-sqrt(1-x^2)

// Ease_Out_Circular
y = sqrt(1-(1-x)^2)
y = sqrt(-(x-2)x)

// Ease_In_Out_Circular
y = (x<0.5) ? (1-sqrt(1-(2x)^2))/2 : 0.5+sqrt(1-((2(1-x))^2))/2
y = (x<0.5) ? 0.5(1-sqrt(1-4x^2)) : 0.5(sqrt(-4(x-2)x-3)+1)

// Ease_In_Bounce
y = 2x^3-x^2
y = x^2(2x-1)

// Ease_In_Bounce_2
y = 3x^3-2x^2
y = x^2(3x-2)

// Ease_In_Bounce_3
y = 4x^3-3x^2
y = x^2(4x-3)

// Ease_Out_Bounce
y = 1-(2(1-x)^3-(1-x)^2)
y = x(x(2x-5)+4)

// Ease_Out_Bounce_2
y = 1-(3(1-x)^3-2(1-x)^2)
y = x(x(3x-7)+5)

// Ease_Out_Bounce_3
y = 1-(4(1-x)^3-3(1-x)^2)
y = x(x(4x-9)+6)

// Ease_In_Out_Bounce
y = (x<0.5) ? (2(2x)^3-(2x)^2)*0.5 : 1-(2(2(1-x))^3-(2(1-x))^2)*0.5
y = (x<0.5) ? 8x^3-2x^2 : 8x^3-22x^2+20x-5

// Ease_In_Out_Bounce_2
y = (x<0.5) ? (3(2x)^3-2(2x)^2)*0.5 : 1-(3(2(1-x))^3-2(2(1-x))^2)*0.5
y = (x<0.5) ? 12x^3-4x^2 : 12x^3-32x^2+28x-7

// Ease_In_Out_Bounce_3
y = (x<0.5) ? (4(2x)^3-3(2x)^2)*0.5 : 1-(4(2(1-x))^3-3(2(1-x))^2)*0.5
y = (x<0.5) ? 16x^3-6x^2 : 16x^3-42x^2+36x-9
```

You can see them in action in any plot service like http://fooplot.com/


#### Next

Planning to render a set of samples to be able to get interpolated values for performance considerations. As another option to cahce, render samples into a texture suitable for shader inputs. Also give full control over the values of these presets, option to blend different easings.


#### License

> Licensed under the [Open Source MIT license](http://en.wikipedia.org/wiki/MIT_License).
