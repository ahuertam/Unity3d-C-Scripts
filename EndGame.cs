using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	void OnTriggerEnter (Collider hit){
		if (hit.gameObject.tag =="Player"){
			Application.LoadLevel("EndGame");
		}
	}
}
