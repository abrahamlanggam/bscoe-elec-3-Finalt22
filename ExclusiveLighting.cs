using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExclusiveLighting : MonoBehaviour
{

	public List<Light> Lights;

	void OnPreCull()
	{
		foreach (Light light in Lights)
		{
			light.enabled = true;
		}
	}

	void OnPostRender()
	{
		foreach (Light light in Lights)
		{
			light.enabled = false;
		}
	}
}