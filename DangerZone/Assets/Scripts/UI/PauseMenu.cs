using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	bool paused = false;
	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("joystick button 7") || Input.GetKeyDown ("o")) 
			{
			paused = togglePause ();
			}
	}



	void MenuUI()
	{
		if (paused) 
		{
			pauseMenu.SetActive(true);
			TweenAlpha.Begin(pauseMenu,1,1);
		}

	}

	public void TtogglePause() {togglePause ();}


	public bool togglePause()
	{
		if (Time.timeScale == 0f) 
		{
			Time.timeScale = 1f;
			pauseMenu.SetActive(false);
			return(false);
		}
		else
		{
			pauseMenu.SetActive(true);
			Time.timeScale = 0f;
			return(true);
		}
	}

	public void LoadMenu()
	{
		paused = false;
		Application.LoadLevel ("Menu");
	}

	public void Quit()
	{
		Application.Quit();
		
	}

	


}
