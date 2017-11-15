using UnityEngine;
using System.Collections;

public class WaterEffect : MonoBehaviour {

	//This script enables underwater effects. Attach to main camera.
	public int underwaterLevel = 7;

	//The scene's default fog settings
	private bool defaultFog;
	private Color defaultFogColor; 
	private float defaultFogDensity;
	private Material defaultSkybox;
	private Material noSkybox;

	void Start () {
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultSkybox = RenderSettings.skybox;
		RenderSettings.fog = true;
		RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
		RenderSettings.fogDensity = 0.2f;
		RenderSettings.skybox = noSkybox;
	}

}