using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public static BackgroundMusicScript BackInstance;
    public AudioSource Audio;
    private void Awake()
    {
        if(BackInstance!=null && BackInstance!=this)
        {
            Destroy(this.gameObject);
            return ;
        }
        BackInstance=this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        Audio=GetComponent<AudioSource>();
    }
}
