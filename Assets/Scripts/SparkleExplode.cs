using UnityEngine;
using System.Collections;

public class SparkleExplode : MonoBehaviour {

	ParticleEmitter emitter;

	//seconds
	public float duration;
	float t;

	// Use this for initialization
	void Start () {

		emitter = gameObject.GetComponent<ParticleEmitter>();

		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t = Mathf.Clamp01(t + Time.deltaTime / duration);
		
		emitter.minEmission = Mathf.Lerp(20, 100, t);
		emitter.maxEmission = Mathf.Lerp(20, 100, t);

		//time to die
		if(t >= 0.3f)
		{
			emitter.emit = false;
			gameObject.transform.parent.renderer.enabled = false;
		}
		if(t == 1)
		{
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}
