using UnityEngine;
using System.Collections;


public class EPPZEasing_Samples_Renderer : MonoBehaviour
{


	public EPPZEasing.EasingType easingType = EPPZEasing.EasingType.Linear;
	public int count = 50;

	private EPPZEasing_Samples samples;

	public LineRenderer lineRenderer;
	public TextMesh nameTextMesh;
	public TextMesh descriptionTextMesh;
	public TextMesh algorithmTextMesh;
	public TextMesh simplifiedAlgorithmTextMesh;


	public void Align()
	{
		// Setup.
		lineRenderer = this.GetComponent<LineRenderer>();
		samples = new EPPZEasing_Samples();

		// Set values.
		samples.easing = EPPZEasing.EasingForType(easingType);
		samples.count = count;
		samples.Calculate();

		// Set renderers.
		lineRenderer.SetVertexCount(count);
		nameTextMesh.text = samples.easing.name;
		descriptionTextMesh.text = samples.easing.description;
		algorithmTextMesh.text = samples.easing.algorithm;
		simplifiedAlgorithmTextMesh.text = samples.easing.simplifiedAlgorithm;

		// Align line renderer vertices.
		float input = 0.0f;
		float value = 0.0f;
		for (int index = 0; index < samples.count; index++)
		{
			input = (float)index * samples.spacing;
			value = samples.samples[index];
			lineRenderer.SetPosition(index, new Vector3(input, value, 0.0f));
		}
	}
}
