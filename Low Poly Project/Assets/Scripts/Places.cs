using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour {

	private AudioSource source;
	[SerializeField] private AudioClip clip;

	void OnTriggerEnter(Collider col) {

		Debug.Log ("You just visited " + gameObject);

		source = col.GetComponent<AudioSource> ();

		source.PlayOneShot (clip, 1.0f);

		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
