EPPZEasing
----------

The very essence of easing algorithms. The easing algorithms here are intended for any use, regardless of time or any known values to change. **It only takes a (mostly linear) input, then spits out an eased output.**

As of above, you can use these algorithms for various reasons, manipulating image contrast, blend any forces nicely weighted, adjusting sound effects depending on distance, or as people do most of the time, you can ease animation keyframes as well of course. 

Simplicity
----------

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

So once you have a linear completion (or any kind of) percentage somewhere in your code, you can just ease it as you like, then go along with the rest of its application.