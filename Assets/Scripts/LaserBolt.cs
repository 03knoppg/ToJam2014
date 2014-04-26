using UnityEngine;
using System.Collections;

public class LaserBolt : Damager {

	public float speed = 5;

	//public float Damage{ get { return damage; } set { damage = value; } }
	
	void FixedUpdate(){
		transform.position += transform.forward * speed;
	}

	void OnTriggerEnter(Collider collider)
	{
		print("BAM! i'm :" + name);
		Destroy(gameObject);
	}
}
