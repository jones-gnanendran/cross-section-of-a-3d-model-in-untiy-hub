using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class AIvsHumanSpriteClicks3: MonoBehaviour
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
    private int clicks=1;
    private int[,] gameStatus=new int[3,3];
    public GameObject helppanel;
    public GameObject congratspanel;
    public TextMeshProUGUI CongratsText;
    public Button helpbutton;
    public GameObject pausepanel;
    private int rounds=4;
    private int currentround=1;
    public TextMeshProUGUI RoundText;
     public TextMeshProUGUI Player1ScoreText;
    public TextMeshProUGUI Player2ScoreText;
    private int Player1Score;
    private int Player2Score;
    public Button PauseButton;
    public GameObject PausePanel;
    public Button GameOverReload;
  public GameObject GameOverPanel;
  public TextMeshProUGUI WinnerText;
    void Start()
    {   
        button1=panel.transform.Find("B1").GetComponent<Button>();
        button2=panel.transform.Find("B2").GetComponent<Button>();
        button3=panel.transform.Find("B3").GetComponent<Button>();
        button4=panel.transform.Find("B4").GetComponent<Button>();
        button5=panel.transform.Find("B5").GetComponent<Button>();
        button6=panel.transform.Find("B6").GetComponent<Button>();
        button7=panel.transform.Find("B7").GetComponent<Button>();
        button8=panel.transform.Find("B8").GetComponent<Button>();
        button9=panel.transform.Find("B9").GetComponent<Button>();

        button1.onClick.AddListener(()=>ButtonClicked(0,0,button1));
        button2.onClick.AddListener(()=>ButtonClicked(0,1,button2));
        button3.onClick.AddListener(()=>ButtonClicked(0,2,button3));
        button4.onClick.AddListener(()=>ButtonClicked(1,0,button4));
        button5.onClick.AddListener(()=>ButtonClicked(1,1,button5));
        button6.onClick.AddListener(()=>ButtonClicked(1,2,button6));
        button7.onClick.AddListener(()=>ButtonClicked(2,0,button7));
        button8.onClick.AddListener(()=>ButtonClicked(2,1,button8));
        button9.onClick.AddListener(()=>ButtonClicked(2,2,button9));
        UpdateRoundText();
    }
    bool haswon=false;
    void ButtonClicked(int row,int col,Button button)
  {
		if(gameStatus[row,col]==0)
		{
			TextMeshProUGUI buttontext=button.GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text="X";
				//button.image.sprite=xsprite;
				gameStatus[row,col]=1;
			    clicks++;
			if(check() && haswon==false)
			{
			Debug.Log("player wins");
            haswon=true;
            congratspanel.SetActive(true);
            CongratsText.text="Player Wins";
            Player1Score++;
             Invoke("ResetGame", 2f); 

			}
			else if(clicks==9)
			{
				Debug.Log("It's a Draw");
			}
            AIMove();
		}
  }
  void AIMove()
  {
  			

         if(clicks%2==0)
         {
        (int bestrow,int bestcol)=FindBest();
        if(bestrow!=-1 && bestcol!=-1)
        {
            Button button=panel.transform.Find($"B{bestrow * 3 + bestcol + 1}").GetComponent<Button>();
            TextMeshProUGUI buttontext=button.GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text="O";
           // button.image.sprite=osprite;
            gameStatus[bestrow,bestcol]=2;
            clicks++;
            if(check() && haswon==false)
            {
                Debug.Log("AI wins");
                haswon=true;
                congratspanel.SetActive(true);
                CongratsText.text="Computer Wins";
                Player2Score++;
                 Invoke("ResetGame", 2f); 
            }
            else if(clicks==9)
            {
                Debug.Log("It's a Draw");
                congratspanel.SetActive(true);
                CongratsText.text="MatchDraw";
                 Invoke("ResetGame", 2f); 
            }
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
  int Evaluate()
  {
        for(int row=0;row<3;row++)
        {
            if(gameStatus[row,0]==gameStatus[row,1] && gameStatus[row,1]==gameStatus[row,2])
            {
                if(gameStatus[row,0]==1)
                {
                    return -10;
                }
                else if(gameStatus[row,0]==2)
                {
                    return +10;
                }
            }
        }
        for(int col=0;col<3;col++)
        {
            if(gameStatus[0,col]==gameStatus[1,col] && gameStatus[1,col]==gameStatus[2,col])
            {
                if(gameStatus[0,col]==1)
                {
                    return -10;
                }
                else if(gameStatus[0,col]==2)
                {
                    return +10;
                }
            }
        }
        if(gameStatus[0,0]==gameStatus[1,1] && gameStatus[1,1]==gameStatus[2,2])
        {
            if(gameStatus[0,0]==1)
            {
                return -10;
            }
            else if(gameStatus[0,0]==2)
            {
                return +10;
            }
        }
        if(gameStatus[0,2]==gameStatus[1,1] && gameStatus[1,1]==gameStatus[2,0])
        {
            if(gameStatus[0,2]==1)
            {
                return -10;
            }
            else if(gameStatus[0,2]==2)
            {
                return +10;
            }
        }
        return 0;
  }
  bool isMovesLeft()
  {
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                if(gameStatus[i,j]==0)
                {
                    return true;
                }
            }
        }
        return false;
  }
  int Minimax(int depth,bool isMax)
  {
        int score=Evaluate();
        if(score==10)
        {
            return score-depth;
        }
        if(score==-10)
        {
            return score+depth;
        }
        if(isMovesLeft()==false)
        {
            return 0;
        }
        if (isMax)
        {
            int best = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameStatus[i, j] == 0)
                    {
                        gameStatus[i, j] = 2;
                        best = Mathf.Max(best, Minimax(depth + 1, !isMax));
                        gameStatus[i, j] = 0;
                    }
                }
            }
            return best;
        }
        else
        {
            int best = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameStatus[i, j] == 0)
                    {
                        gameStatus[i, j] = 1;
                        best = Mathf.Min(best, Minimax(depth + 1, !isMax));
                        gameStatus[i, j] = 0;
                    }
                }
            }
            return best;
        }
}
(int ,int) FindBest()
{
    int bestval=int.MinValue;
    int bestrow=-1;
    int bestcol=-1;
    for(int i=0;i<3;i++)
    {
        for(int j=0;j<3;j++)
        {
            if(gameStatus[i,j]==0)
            {
                gameStatus[i,j]=2;
                int moveval=Minimax(0,false);
                gameStatus[i,j]=0;
                if(moveval>bestval)
                {
                    bestrow=i;
                    bestcol=j;
                    bestval=moveval;
                }
            }
        }
    }
    return (bestrow,bestcol);
}
public void helpClose()
{
    
    helppanel.SetActive(false);
    panel.SetActive(true);
}
public void helpbuttonclicked()
{
    helppanel.SetActive(true);
    panel.SetActive(false);
}

void ResetGame()
  {	
		
			if(currentround<rounds)
			{	
				currentround++;
				congratspanel.SetActive(false);
				clicks=1;
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
        Player1ScoreText.text="Player "+Player1Score;
        Player2ScoreText.text="Computer "+Player2Score;
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
			WinnerText.text="Computer wins";
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
