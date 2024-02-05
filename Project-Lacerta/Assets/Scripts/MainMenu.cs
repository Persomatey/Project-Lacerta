using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

	[SerializeField] GameObject mainMenuPanel; 
	[SerializeField] GameObject howToPlayPanel;

	private void Awake()
	{
		StartCoroutine(DelayStartMusic()); 
	}

	IEnumerator DelayStartMusic()
	{
		yield return new WaitForEndOfFrame(); 
		yield return new WaitForEndOfFrame(); 
		yield return new WaitForEndOfFrame(); 
		AudioSystem.instance.PlayGameplayMusic(); 
	}

	public void StartGame()
	{ 
		AudioSystem.instance.PlayMenuSelectionSFX();
		StartCoroutine(DelayPlayGame(0.5f)); 
	}

	public void HowToPlay()
	{
		mainMenuPanel.SetActive(false); 
		howToPlayPanel.SetActive(true); 
		AudioSystem.instance.PlayMenuSelectionSFX();
	}

	public void ExitGame()
	{
		AudioSystem.instance.PlayMenuSelectionBackSFX();
		StartCoroutine(DelayQuitGame(0.5f)); 
	}

	public void DismissHowToPlayPanel()
	{
		mainMenuPanel.SetActive(true); 
		howToPlayPanel.SetActive(false); 
		AudioSystem.instance.PlayMenuSelectionBackSFX();
	}

	IEnumerator DelayPlayGame(float del)
	{
		yield return new WaitForSeconds(del); 
		SceneManager.LoadScene("SampleScene"); 
	}

	IEnumerator DelayQuitGame(float del)
	{
		yield return new WaitForSeconds(del); 
		Application.Quit(); 
	}
}
