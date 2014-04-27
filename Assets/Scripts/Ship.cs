using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Ship : MonoBehaviour
{
	public GameObject exploder;
	public GameObject lazor;

	public float lazorCD;
	float lastFired;
	public Vector3 lazorOffset;
	bool dead;

	void OnTriggerEnter(Collider collider)
	{
		print("BAM! i'm :" + name);
		Damager damager;
		if(!dead && (damager = collider.gameObject.GetComponent<Damager>()) != null)
		{
			print("Owch " + damager.Damage);

			GameObject exploder2 = (GameObject) Instantiate(exploder);
			exploder2.transform.parent = transform;
			exploder2.transform.localPosition = Vector3.zero;

			dead = true;
		}
	}

	void Start()
	{
		Contols.OnPressed += (laserColour colour) => 
		{
				fireLazors (colour);
		};
		
	}


	public void fireLazors(laserColour colour)
	{
		print (colour);
		if (Time.time - lastFired > lazorCD) {
			print ("Fire");
			lastFired = Time.time;
			GameObject lazor2 = (GameObject)Instantiate (lazor);

			lazor2.transform.position = transform.position + lazorOffset;
			lazor2.transform.rotation = transform.rotation;

			if(colour == laserColour.blue)
				lazor2.renderer.material.SetColor("_Color", Color.blue);
			else if(colour == laserColour.red)
				lazor2.renderer.material.SetColor("_Color", Color.red);
			else if(colour == laserColour.green)
				lazor2.renderer.material.SetColor("_Color", Color.green);
			else if(colour == laserColour.yellow)
				lazor2.renderer.material.SetColor("_Color", Color.yellow);

		}
	}
}


