using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Ship : MonoBehaviour
{
	public Exploder exploder;
	public Weapon weapon;

	GameObject Exploder;
	GameObject Lazor;

	public float lazorCD;
	float lastFired;
	public Vector3 lazorOffset;
	bool dead;

	Vector3 oldPostition;


	void OnTriggerEnter(Collider collider)
	{
		if(collider.GetComponent<LaserBolt>() != null && collider.GetComponent<LaserBolt>().source == gameObject)
			return;

		print("BAM! i'm :" + name);
		Damager damager;
		if(!dead )//&& (damager = collider.gameObject.GetComponent<Damager>()) != null)
		{
			//print("Owch " + damager.Damage);
			print ("Killed by: " + collider.gameObject.name);
			GameObject exploder2 = (GameObject) Instantiate(Exploder);
			exploder2.transform.parent = transform;
			exploder2.transform.localPosition = Vector3.zero;
			exploder2.GetComponent<SparkleExplode>().duration = 1.5f;

			dead = true;


		}
	}

	void Update()
	{
		print ("Velocity " + (transform.position - oldPostition).magnitude);
		//lazorOffset = new Vector3(2 + (transform.position - oldPostition).magnitude, 0, 0);
		oldPostition = transform.position;
	}

	void Start()
	{
		Contols.OnPressed += fireLazors;	

		Exploder = Connector.GetConnection(exploder);
		Lazor = Connector.GetConnection(weapon); 
	}

	void OnDestroy(){
		Contols.OnPressed -= fireLazors;
	}

	public void fireLazors()
	{
		//print (colour);
		if (Time.time - lastFired > lazorCD) {
			print ("Fire");
			lastFired = Time.time;
			GameObject lazor2 = (GameObject)Instantiate (Lazor);

			print ("SHOOTING");
			lazor2.transform.position = transform.position + lazorOffset;
			lazor2.transform.rotation = transform.rotation;
			lazor2.GetComponent<LaserBolt>().speed += (transform.position - oldPostition).magnitude * 5;


		}
	}
}


