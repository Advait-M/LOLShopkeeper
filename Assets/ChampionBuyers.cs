using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ChampionBuyers : MonoBehaviour
{

	Dictionary<String, String> champions = new Dictionary<string, string>();
	int currentIndex = 0;
	bool championExists = false;
	string currentChamp = "";
	GameObject theChamp;

	// Use this for initialization
	void Start()
	{
		champions.Add("Ashe", "Infinity Edge");
		champions.Add("Cassio", "Boots of Speed");
		champions.Add("Caitlyn", "Trinity Force");
		champions.Add("Sejuani", "Warmog's Armor");
		List<String> championNames = new List<String>(champions.Keys);
		theChamp = Instantiate(GameObject.Find(championNames[currentIndex]), transform.position, transform.rotation);
		currentChamp = championNames[currentIndex];
		currentIndex = UnityEngine.Random.Range (0, 3);
		championExists = true;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (!championExists)
		{
			//Debug.Log("Instantiated new champ on updated");
			StartCoroutine (updateChamp());
		}
	}
	IEnumerator updateChamp()
	{
		championExists = true;
		yield return new WaitForSeconds(5);
		List<String> championNames = new List<String>(champions.Keys);
		theChamp = Instantiate(GameObject.Find(championNames[currentIndex]), transform.position, transform.rotation);
		currentChamp = championNames[currentIndex];
		Debug.Log("New Champion: " + championNames[currentIndex]);
		currentIndex = UnityEngine.Random.Range (0, 3);
	}

	void OnTriggerEnter(Collider item)
	{
		Debug.Log("Item in Champion Spawner: " + item.name);
		if (item.name.StartsWith(champions[currentChamp]))
		{
			Debug.Log("Item Matches Champion Desire");
			championExists = false;
			Destroy(theChamp);
			Destroy(item.gameObject);
		}
	}
}
