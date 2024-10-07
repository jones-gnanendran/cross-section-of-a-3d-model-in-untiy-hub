using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sfxManager : MonoBehaviour
{
   public AudioSource Audio;
   public AudioClip Click;

   public static sfxManager sfxInstance;
   public bool musicToggle=true;
   private void Awake()
    {
        if( sfxInstance!=null &&  sfxInstance!=this)
        {
            Destroy(this.gameObject);
            return ;
        }
         sfxInstance=this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    
}
