using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

	private AudioSource source;
	[SerializeField] private AudioClip clip;

	CollectiblesController cc;
    HUDController hc;

    public bool playerDead = false;

	void Start(){
	
		GameObject ccgo = GameObject.Find ("CollectiblesController");
		cc = ccgo.GetComponent<CollectiblesController> ();

        GameObject hcgo = GameObject.Find("HUDController");
        hc = hcgo.GetComponent<HUDController>();

    }

	void OnTriggerEnter(Collider col) {

		Debug.Log ("You just picked up " + gameObject);

		source = col.GetComponent<AudioSource> ();

		source.PlayOneShot (clip, 1.0f);

		cc.incrementCount (gameObject);

        cc.AddItemToList(gameObject);

        hc.healthBar.fillAmount += 0.02f;

        Destroy (gameObject);
	}

    public void PlayerIsDead()
    {
        if (hc.healthBar.fillAmount == 0f && playerDead == false)
        {
            playerDead = true;
            Debug.Log("YOU ARE DEAD");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        
    }
		
}
