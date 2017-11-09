using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Spawner : MonoBehaviour {
	void Start() {
		if (GetComponent<VRTK_InteractableObject> () == null) {
			return;
		}

		GetComponent<VRTK_InteractableObject> ().InteractableObjectGrabbed += new InteractableObjectEventHandler (ObjectGrabbed);
	}

	private void ObjectGrabbed(object sender, InteractableObjectEventArgs e) {
		Instantiate ((VRTK_InteractableObject)sender);
	}
}
