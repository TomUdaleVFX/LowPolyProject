using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public AudioSource musicSource;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
        else
            musicSource.Play();
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public InputField nameField;

    // Player name variable and property to access
    // it from other scripts.
    string playerName;
    public string PlayerName
    {
        get { return playerName; }
        set { Debug.Log("You are not allowed to set the player name like that"); }
    }

    //Use this on a "Submit" button to set the playerName variable.
    public void SubmitName()
    {
        if (string.IsNullOrEmpty(nameField.text) == false)
        {
            playerName = nameField.text;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
