using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		print (other.GetComponent<Material>());
	}

	void OnTriggerExit(Collider other)
	{
		print (other.GetComponent<Material>());
	}

	// Update is called once per frame
	void Update () {
		
	}
}
