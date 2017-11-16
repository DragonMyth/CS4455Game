using UnityEngine;
using System.Collections;

public class BubbleEffect : MonoBehaviour {

	public Material[] materials;

	private ParticleEmitter particlEmitter;
	private ParticleAnimator particlAnimator;
	private ParticleRenderer particlRenderer;

	private float speed;

	void Start() {
		particlEmitter = gameObject.AddComponent<EllipsoidParticleEmitter>();
		particlAnimator = gameObject.AddComponent<ParticleAnimator>();
		particlRenderer = gameObject.AddComponent<ParticleRenderer>();

		particlEmitter.minSize = 0.1f;
		particlEmitter.maxSize = 0.2f;
		particlEmitter.minEnergy = 0.5f;
		particlEmitter.maxEnergy = 2;
		particlEmitter.minEmission = 10;
		particlEmitter.maxEmission = 20;

		particlAnimator.doesAnimateColor = false;
		particlAnimator.sizeGrow = 0.5f;

//		particlAnimator.force.y = 2;

		particlRenderer.materials = materials;
	}

	void Update() {
		speed = GetComponent<Rigidbody>().velocity.magnitude*3;
		particlEmitter.minEmission = speed;
		particlEmitter.maxEmission = particlEmitter.minEmission*2;
	}
}