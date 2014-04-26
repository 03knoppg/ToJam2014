using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Ship : MonoBehaviour
{

	void OnTriggerEnter(Collider collider)
	{
		print("BAM! i'm :" + name);
		Damager damager;
		if((damager = collider.gameObject.GetComponent<Damager>()) != null)
		{
			print("Owch " + damager.Damage);

		}
	}
}


