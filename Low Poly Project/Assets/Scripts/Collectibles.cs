using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

	private AudioSource source;
	[SerializeField] private AudioClip clip;

	CollectiblesController cc;

	void Start(){
	
		GameObject ccgo = GameObject.Find ("CollectiblesController");
		cc = ccgo.GetComponent<CollectiblesController> ();
		
	}

	void OnTriggerEnter(Collider col) {

		Debug.Log ("You just picked up " + gameObject);

		source = col.GetComponent<AudioSource> ();

		source.PlayOneShot (clip, 1.0f);

		cc.incrementCount (gameObject);

		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
		
}
