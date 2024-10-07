using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    
    public  int rounds;
     public static GameController Instance;
      void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Setrounds(int total)
    {
        rounds=total;
        Debug.Log("Total no of rounds:"+rounds);
    }
    public int getrounds()
    {   
        return rounds;
    }
}
