using UnityEngine;
using System.Collections;

public class LaserBolt : Damager {

	public float speed = 5;
	float life = 5;
	float time;
	public GameObject source;

	//public float Damage{ get { return damage; } set { damage = value; } }
	void Start(){
		time = Time.time;
	}


	void FixedUpdate(){
		if(Time.time - time > life)
			Destroy(gameObject);

		transform.position += transform.forward * speed;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject == source)
			return;
		//print("BAM! i'm :" + name);
		Destroy(gameObject);
	}
}
