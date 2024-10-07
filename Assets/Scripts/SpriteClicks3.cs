using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SpriteClicks3: MonoBehaviour
{
  public GameObject panel;
  public Button button1; 
  public Button button2;
  public Button button3;
  public Button button4;
  public Button button5;
  public Button button6;
  public Button button7;
  public Button button8;
  public Button button9;
  public Sprite xsprite;
  public Sprite osprite;
  private int clicks=0;
  private int [,] gameStatus=new int[3,3];
  public GameObject congratspanel;
  public GameObject helppanel;
  public TextMeshProUGUI CongratsText;
  public Button Help;
  public GameController gamecontroller;
  public  int rounds=4;
  private int currentround=1;
  public TextMeshProUGUI RoundText;
  private int Player1Score;
  private int Player2Score;
  public TextMeshProUGUI Player1ScoreText;
  public TextMeshProUGUI Player2ScoreText;
  public Button pauseButton;
  public GameObject PausePanel;
  public Button GameOverReload;
  public GameObject GameOverPanel;
  public TextMeshProUGUI WinnerText;
  //0 means no value is filled  1 means x is filled  2 means o is filled
  void Start()
  {		
		Debug.Log(rounds);
		button1 = panel.transform.Find("B1").GetComponent<Button>();
        button2 = panel.transform.Find("B2").GetComponent<Button>();
		button3 = panel.transform.Find("B3").GetComponent<Button>();
		button4 = panel.transform.Find("B4").GetComponent<Button>();
		button5 = panel.transform.Find("B5").GetComponent<Button>();
		button6 = panel.transform.Find("B6").GetComponent<Button>();
		button7 = panel.transform.Find("B7").GetComponent<Button>();
		button8 = panel.transform.Find("B8").GetComponent<Button>();
		button9 = panel.transform.Find("B9").GetComponent<Button>();

		button1.onClick.AddListener(() => ButtonClicked(0,0,button1));
		button2.onClick.AddListener(() => ButtonClicked(0,1,button2));
		button3.onClick.AddListener(() => ButtonClicked(0,2,button3));
		button4.onClick.AddListener(() => ButtonClicked(1,0,button4));
		button5.onClick.AddListener(() => ButtonClicked(1,1,button5));
		button6.onClick.AddListener(() => ButtonClicked(1,2,button6));
		button7.onClick.AddListener(() => ButtonClicked(2,0,button7));
		button8.onClick.AddListener(() => ButtonClicked(2,1,button8));
		button9.onClick.AddListener(() => ButtonClicked(2,2,button9));
		UpdateRoundText();
		
  }
  bool haswon=false;
  void ButtonClicked(int row,int col,Button button)
  {
		if(gameStatus[row,col]==0)
		{
			clicks++;
			TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

			if(clicks%2!=0)
			{
				 buttonText.text = "X";
				gameStatus[row,col]=1;
			}
			else
			{
				buttonText.text="O";
				gameStatus[row,col]=2;
			}
			if(check() && haswon==false)
			{
			Debug.Log("winner");
			haswon=true;
			
			congratspanel.SetActive(true);
			 if(clicks%2!=0 && clicks!=9)
			{
				CongratsText.text="Player1 Wins";
				Player1Score++;
				
				
			}
			else 
			{
				CongratsText.text="Player2 Wins";
				Player2Score++;
				
				
				
			}
			 Invoke("ResetGame", 2f);
			}
			else if(clicks==9)
			{
				congratspanel.SetActive(true);
				CongratsText.text="Match Draw";
				 Invoke("ResetGame", 2f); 
			}
			
		}
  }
  
  bool check()
  {
		if(gameStatus[0,0]!=0 && gameStatus[0,0]==gameStatus[1,1] && gameStatus[1,1]==gameStatus[2,2])
		{
			return true;
		}
		if(gameStatus[0,2]!=0 && gameStatus[0,2]==gameStatus[1,1] && gameStatus[1,1]==gameStatus[2,0])
		{
			return true;
		}
		for(int i=0;i<3;i++)
		{
			if(gameStatus[i,0]!=0 && gameStatus[i,0]==gameStatus[i,1] && gameStatus[i,1]==gameStatus[i,2])
			{
				return  true;
			}
			if(gameStatus[0,i]!=0 && gameStatus[0,i]==gameStatus[1,i] && gameStatus[1,i]==gameStatus[2,i])
			{
				return true;
			}
		}
		return false;

  }
  public void helpClose()
  {
		
		helppanel.SetActive(false);
  }
  public void helpOpen()
  {
		helppanel.SetActive(true);
  }
  void ResetGame()
  {	
		
			if(currentround<rounds)
			{	
				currentround++;
				congratspanel.SetActive(false);
				clicks=0;
				haswon=false;
				gameStatus=new int[3,3];
				ClearButtonText(button1);
				ClearButtonText(button2);
				ClearButtonText(button3);
				ClearButtonText(button4);
				ClearButtonText(button5);
				ClearButtonText(button6);
				ClearButtonText(button7);
				ClearButtonText(button8);
				ClearButtonText(button9);
				UpdateRoundText();
				UpdateScore();
			}
			else{
			Debug.Log("Game Over");
			UpdateScore();
			congratspanel.SetActive(false);
			RoundText.text="";
			Player1ScoreText.text="";
			Player2ScoreText.text="";
			GameOverfn();
			}
  }
  void ClearButtonText(Button button)
  {
		TextMeshProUGUI buttonText=button.GetComponentInChildren<TextMeshProUGUI>();
		buttonText.text="";
  }
  void UpdateRoundText()
  {
		RoundText.text="Round "+ currentround;
  }
  void UpdateScore()
  {
		Player1ScoreText.text="Player1 "+Player1Score;
		Player2ScoreText.text="Player2 "+Player2Score;
  }

  public void PauseGame()
  {
		PausePanel.SetActive(true);
  }
  public void ResumeGame()
  {
		PausePanel.SetActive(false);
  }
  public void ReloadGame()
  {
				congratspanel.SetActive(false);
				clicks=0;
				haswon=false;
				gameStatus=new int[3,3];
				ClearButtonText(button1);
				ClearButtonText(button2);
				ClearButtonText(button3);
				ClearButtonText(button4);
				ClearButtonText(button5);
				ClearButtonText(button6);
				ClearButtonText(button7);
				ClearButtonText(button8);
				ClearButtonText(button9);
				currentround=1;
				Player2ScoreText.text="";
				Player1ScoreText.text="";
				PausePanel.SetActive(false);
				Player1Score=0;
				Player2Score=0;
				UpdateRoundText();
  }
  public void home()
  {
		SceneManager.LoadScene(0);
  }
   void GameOverfn()
  {
		panel.SetActive(false);
		GameOverPanel.SetActive(true);
		if(Player1Score>Player2Score)
		{
			WinnerText.text="Player1 wins";
		}
		else if(Player1Score<Player2Score)
		{
			WinnerText.text="Player2 wins";
		}
		else if(Player1Score== Player2Score)
		{
			WinnerText.text="Match Draw";
		}
  }
  public void GameOverReloadfn()
  {
		panel.SetActive(true);
		GameOverPanel.SetActive(false);
		ReloadGame();
  }
}
