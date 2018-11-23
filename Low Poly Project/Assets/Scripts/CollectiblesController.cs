using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CollectiblesController : MonoBehaviour {

	public CollectiblesData[] cd;

	void Awake(){
	
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1) {
		
			Destroy (gameObject);
		
		}
	
	}


	void Update(){
	
		if (Input.GetKeyDown ("l")) {
		
			Debug.Log ("Loading");
			LoadData ();
		
		} else if (Input.GetKeyDown ("s")) {
		
			Debug.Log ("Saving");
			SaveData ();
		
		}
	
	}

	public void incrementCount(GameObject go)
	{

		if (go.name.Contains ("Food")) {
		
			cd [0].collectibleNum++;
		
		}

		if (go.name.Contains ("Coconut")) {

			cd [1].collectibleNum++;

		}

		if (go.name.Contains ("Stone")) {

			cd [2].collectibleNum++;

		}

        if (go.name.Contains("Plank")) {

            cd[3].collectibleNum++;

        }

    }

	void outputCounts()
	{
	
		Debug.Log ("You've collected:");
		Debug.Log ("Food = " + cd [0].collectibleNum);
		Debug.Log ("Coconuts = " + cd [1].collectibleNum);
		Debug.Log ("Stones = " + cd [2].collectibleNum);
        Debug.Log("Wooden Planks = " + cd[2].collectibleNum);

    }

	public void SaveData(){
	
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/gameData.dat");
		bf.Serialize (fs, cd);
		fs.Close ();
		Debug.Log ("Save Data");
	
	}

	public void LoadData(){
	
		if (File.Exists (Application.persistentDataPath + "/gameData.dat")) {
		
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/gameData.dat", FileMode.Open);
			cd = (CollectiblesData[])bf.Deserialize (fs);
			fs.Close ();
			Debug.Log ("Loading Data");
		
		} else {
		
			Debug.LogError ("404");
		
		}
	}

}
