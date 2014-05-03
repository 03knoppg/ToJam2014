using UnityEngine;
using System.Collections;

public class SparkleExplode : MonoBehaviour {



	ParticleEmitter emitter;

	//seconds
	public float duration;
	float t;
	bool dead;

	// Use this for initialization
	void Start () {

		emitter = gameObject.GetComponent<ParticleEmitter>();

		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(dead)
			return;

		t = Mathf.Clamp01(t + Time.deltaTime / duration);
		
		emitter.minEmission = Mathf.Lerp(20, 100, t * 2);
		emitter.maxEmission = Mathf.Lerp(20, 100, t * 2);

		//time to die
		if(t >= 0.3f && emitter.emit)
		{
			emitter.emit = false;
			if(gameObject.transform.parent.renderer == null)
				return;

			gameObject.transform.parent.renderer.enabled = false;
			foreach(Transform trans in gameObject.transform.parent.transform){
				if(trans != transform)
					trans.gameObject.SetActive(false);
			}
		}
		if(t == 1)
		{
			dead = true;
			print ("Im " + gameObject.transform.parent.name);
			if(gameObject.transform.parent.name != "Done_Player")
				Destroy(gameObject.transform.parent.gameObject);
			else
				Invoke ("RestartLevel", 1.5f);
		}
	}

	void RestartLevel()
	{
		print ("RESTART");
		Application.LoadLevel(Application.loadedLevel);

	}
}
