using UnityEngine;
using System.Collections;

public class Latcher : MonoBehaviour {


	void OnTriggerEnter(Collider collider)
	{
		if ((collider.name=="Done_Enemy Ship Green" || collider.name=="Done_Enemy Ship Red" || collider.name=="Done_Enemy Ship Blue" || collider.name=="Done_Enemy Ship Yellow") && collider.gameObject.GetComponent<EnemyControls>().isLatcher) {
			collider.transform.parent = transform.parent;
		}
	}

}
