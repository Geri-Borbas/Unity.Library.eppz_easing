using UnityEngine;
using System.Collections;


public class EPPZEasing_Samples
{


	public EPPZEasing easing = EPPZEasing.EasingForType(EPPZEasing.EasingType.Linear);
	public int count;

	private float[] _samples;
	public float[] samples { get { return _samples; } }

	private int _spacings;
	public int spacings { get { return _spacings; } }

	private float _spacing;
	public float spacing { get { return _spacing; } }
		

	public void Calculate()
	{
		// Helper values.
		_spacings = count - 1;
		_spacing = 1.0f / (float)spacings;

		// Allocate.
		_samples = new float[count];

		// Fill up samples.
		for (int index = 0; index < count; index++)
		{
			float input = (float)index / (float)_spacings;
			samples[index] = easing.ValueForInput(input);
		}
	}
}
