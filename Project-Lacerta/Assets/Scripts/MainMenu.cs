using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

	[SerializeField] GameObject mainMenuPanel; 
	[SerializeField] GameObject howToPlayPanel; 

	public void StartGame()
	{ 
		// Load scene 
		SceneManager.LoadScene("SampleScene"); 
	}

	public void HowToPlay()
	{
		// show controls 
		mainMenuPanel.SetActive(false); 
		howToPlayPanel.SetActive(true); 
	}

	public void ExitGame()
	{
		Application.Quit(); 
	}

	public void DismissHowToPlayPanel()
	{
		mainMenuPanel.SetActive(true); 
		howToPlayPanel.SetActive(false); 
	}
}
