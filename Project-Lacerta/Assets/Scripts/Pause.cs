using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	[SerializeField] GameObject gameCanvas; 
	[SerializeField] GameObject pauseCanvas;

	private void Update()
	{
		if ( Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) )
		{
			gameCanvas.SetActive(false); 
			pauseCanvas.SetActive(true); 
			Time.timeScale = 0; 
		}
	}

	public void UnPause() 
	{
		gameCanvas.SetActive(true); 
		pauseCanvas.SetActive(false); 
		Time.timeScale = 1; 
		AudioSystem.instance.PlayMenuSelectionSFX();
	}

	public void MainMenu() 
	{
		Debug.Log("Going back to main menu"); 
		Time.timeScale = 1; 
		AudioSystem.instance.PlayMenuSelectionSFX();
		StartCoroutine( DelayMainMenu(0.5f) ); 
	}

	IEnumerator DelayMainMenu(float del)
	{
		yield return new WaitForSeconds(del); 
		Debug.Log("main menu now"); 
		SceneManager.LoadScene("MainMenu"); 
	}
}
