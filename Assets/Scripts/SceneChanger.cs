using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
	public GameObject ModePanel;
	public GameObject RoundsPanel;
	public int count=0;
	private int selectedMode;
	public void play()
	{
		SceneManager.LoadScene(1);
		if(sfxManager.sfxInstance.musicToggle==true)
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
	}
	public void onevone()
	{	selectedMode=1;
	RoundsPanel.SetActive(true);
	
		if(sfxManager.sfxInstance.musicToggle==true)
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
		
	}
	public void AI()
	{	selectedMode=2;
		RoundsPanel.SetActive(true);
		
		if(sfxManager.sfxInstance.musicToggle==true)
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
	}
	
	public void OnOneRoundClick()
	{
		count=1;
		
		if(sfxManager.sfxInstance.musicToggle==true)
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
	}
	public void OnTwoRoundClick()
	{
		count=2;
		
		if(sfxManager.sfxInstance.musicToggle==true)
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);

	}
	public void OnThreeRoundclick()
	{
		count=3;
		
		if(sfxManager.sfxInstance.musicToggle==true)
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
	}
	public void OnFourthRoundclick()
	{
		count=4;
		
		if(sfxManager.sfxInstance.musicToggle==true)
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
	}
	public void GoButtonCick()
	{
		sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
		if(selectedMode==1 && count==1)
		{
			SceneManager.LoadScene(2);
			if(sfxManager.sfxInstance.musicToggle==true)
			sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
		}
		else if(selectedMode==1 && count==2)
		{
			SceneManager.LoadScene(3);
		}
		else if(selectedMode==1 && count==3)
		{
			SceneManager.LoadScene(4);
		}
		else if(selectedMode==1 && count==4)
		{
			SceneManager.LoadScene(5);
		}
		else if(selectedMode==2 && count==1)
		{
			SceneManager.LoadScene(6);
			if(sfxManager.sfxInstance.musicToggle==true)
			sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
		}
		else if(selectedMode==2 && count==2)
		{
			SceneManager.LoadScene(7);
		}
		else if(selectedMode==2 && count==3)
		{
			SceneManager.LoadScene(8);
		}
		else if(selectedMode==2 && count==4)
		{
			SceneManager.LoadScene(9);
		}
	}
	

}
