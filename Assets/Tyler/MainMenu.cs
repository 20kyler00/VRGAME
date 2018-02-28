using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public void PlayEasy ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void PlayNormal ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 2);
	}

	public void PlayHard ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 3);
	}

	public void Quit ()
	{
		Application.Quit ();
	}
}
