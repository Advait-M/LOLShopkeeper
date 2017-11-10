using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ChampionBuyers : MonoBehaviour
{

	Dictionary<String, String> champions = new Dictionary<string, string>();
	int playedTimes = 0;
	bool championExists = false;
	string currentChamp = "";
	GameObject theChamp;

	// Use this for initialization
	void Start()
	{
		champions.Add("Ashe", "Infinity Edge");
		champions.Add("Cassio", "Tear of the Goddess");
		champions.Add("Minion", "Serrated Dirk");
		champions.Add("Sejuani", "Negatron Cloak");
		champions.Add("Darius", "Warmog's Armor");
		List<String> championNames = new List<String>(champions.Keys);
		Debug.Log("TEST" + championNames[playedTimes]);
		theChamp = Instantiate(GameObject.Find(championNames[playedTimes]), transform.position, transform.rotation);
		currentChamp = championNames[playedTimes];
		playedTimes++;
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
		Debug.Log("TEST RUN??");
		championExists = true;
		yield return new WaitForSeconds(5);
		List<String> championNames = new List<String>(champions.Keys);
		Instantiate(GameObject.Find(championNames[playedTimes]), transform.position, transform.rotation);
		Debug.Log("Instantiated: " + championNames[playedTimes]);
		currentChamp = championNames[playedTimes];
		playedTimes++;
	}

	void OnTriggerEnter(Collider item)
	{
		Debug.Log("Item in spawner" + item.name);
		if (item.name.Equals(champions[currentChamp]))
		{
			Debug.Log("Destroyed!!");
			championExists = false;
			Destroy(theChamp);
			Destroy(item.gameObject);
		}
	}
}
