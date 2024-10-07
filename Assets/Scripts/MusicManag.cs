using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MusicManag : MonoBehaviour
{
   public TextMeshProUGUI MusicText;
   public Sprite MusicOff;
   public Sprite MusicOn;
   public Button button;
   public TextMeshProUGUI SoundText;
   public Sprite SoundOn;
   public Sprite SoundOff;
   public Button soundbutton;

   private void Start()
   {
		if(BackgroundMusicScript.BackInstance.Audio.isPlaying)
		  {
			
			button.image.sprite=MusicOn;
			MusicText.text="Music On";
			}
		  else
		  {
			button.image.sprite=MusicOff;
			MusicText.text="Music Off";
		  }

		  if(sfxManager.sfxInstance.musicToggle==true)
		  {
				soundbutton.image.sprite=SoundOn;
				SoundText.text="Sound On";
		  }
		  else
		  {
			 soundbutton.image.sprite=SoundOff;
				SoundText.text="Sound Off";
		  }
   }
   public void MusicToggle()
   {
		  if(BackgroundMusicScript.BackInstance.Audio.isPlaying)
		  {
			BackgroundMusicScript.BackInstance.Audio.Pause();
			button.image.sprite=MusicOff;
		  }
		  else
		  {
				BackgroundMusicScript.BackInstance.Audio.Play();
				button.image.sprite=MusicOn;
		  }
   }
   public void sfxToggle()
   {
		  if(sfxManager.sfxInstance.musicToggle==true)
		  {
				sfxManager.sfxInstance.musicToggle=false;
				soundbutton.image.sprite=SoundOff;
				SoundText.text="Sound Off";
		  }
		  else
		  {
				sfxManager.sfxInstance.musicToggle=true;
				soundbutton.image.sprite=SoundOn;
				SoundText.text="Sound On";
		  }
   }
}
