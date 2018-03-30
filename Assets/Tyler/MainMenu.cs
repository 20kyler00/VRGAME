using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public void PlayEasy ()
	{
		PlayerPrefs.SetString("difficulty","Easy");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void PlayNormal ()
	{
		PlayerPrefs.SetString("difficulty","Normal");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void PlayHard ()
	{
		PlayerPrefs.SetString("difficulty","Hard");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void ReturnMain ()
	{
		SceneManager.LoadScene ("MainMenu");
	}
	public void Quit ()
	{
		Application.Quit ();
	}
}
