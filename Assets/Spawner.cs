using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Spawner : MonoBehaviour {
	public bool IsSpawnable;
	public string ItemName;

	void Start() {
		if (GetComponent<VRTK_InteractableObject> () == null) {
			return;
		}

		GetComponent<VRTK_InteractableObject> ().InteractableObjectGrabbed += new InteractableObjectEventHandler (ObjectGrabbed);
	}

	private void ObjectGrabbed(object sender, InteractableObjectEventArgs e) {
		VRTK_InteractableObject obj = (VRTK_InteractableObject)sender;
		GameObject world = GameObject.Find ("World");
		if (this.IsSpawnable) {
			obj.ToggleHighlight (false);
			VRTK_InteractableObject newObject = Instantiate (obj, world.transform);
			newObject.ToggleHighlight (false);
			this.IsSpawnable = false;
		}
	}
}
