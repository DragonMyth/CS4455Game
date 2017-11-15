using UnityEngine;
using System.Collections;

public class WaterEffect : MonoBehaviour {

	//This script enables underwater effects. Attach to main camera.
	public int underwaterLevel = 7;

	//The scene's default fog settings
	private bool defaultFog = RenderSettings.fog;
	private Color defaultFogColor = RenderSettings.fogColor;
	private float defaultFogDensity = RenderSettings.fogDensity;
	private Material defaultSkybox = RenderSettings.skybox;
	private Material noSkybox;

	void Start () {
		RenderSettings.fog = true;
		RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
		RenderSettings.fogDensity = 0.2f;
		RenderSettings.skybox = noSkybox;
	}

}