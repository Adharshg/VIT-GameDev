using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text display;
	public Text Run;
	public Text Score;
	public Text Bats;
	public Text OABLeft;
	public GameObject FirstPanel;
	public GameObject SecondPanel;

	public int Overs = 5;
	public int BallsPerOver = 6;
	public int batsmen = 5;

	public AudioSource yay;
	public AudioSource missed;
	public AudioSource Out;
	public AudioSource Victory;

	private string grid = "";
	private string bowler = "";
	private string delivery;
	private int score = 0;
	private int balls = 6;

     // Start is called before the first frame update
    void Start()
    {
    	Bowling();
        Run.text = "-";
    }

    void Update(){

    	if (grid != "" && bowler != ""){
    		Batting();
    	}

    	if (batsmen <= 0){
    		GameOver();
    	}

    	if (score >= 60){
    		Win();
    	}

    	Score.text = "Score: " + score;
    	Bats.text = batsmen + " batsmen remaining";
    }

    public void SelectGrid(Button GridButton){
        grid = "" + GridButton.name;
    }

    public void SelectBowler(Button BowlerButton){
    	bowler = "" + BowlerButton.name;

    }

    public void Batting(){
    	delivery = bowler + " grid " + grid;
    	display.text = delivery;
    	bowler = "";
    	grid = "";
    	FirstPanel.SetActive(false);
    	SecondPanel.SetActive(true);
    }

    public void RunSelect(Button RunButton){

    	bool missed = false;
    	int run = int.Parse(RunButton.name);
    	float chance = UnityEngine.Random.Range(0f,1f);
    	
    	switch(run){
    		case 0:
    			if (chance < 0.9f){
    				Run.text = "0 runs";
    				yay.Play();
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 1:
    			if (chance < 0.9f){
    				Run.text = "1 runs";
    				yay.Play();
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 2:
    			if (chance < 0.85f){
    				Run.text = "2 runs";
    				yay.Play();
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 3:
    			if (chance < 0.6f){
    				Run.text = "3 runs";
    				yay.Play();
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 4:
    			if (chance < 0.35f){
    				Run.text = "4 runs!";
    				Victory.Play();
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 6:
    			if (chance < 0.2f){
    				Run.text = "6 runs!!";
    				Victory.Play();
    			}
    			else{
    				missed = true;
    			}
    			break;
    	}
    	if (missed){
    		float missedOrOut = UnityEngine.Random.Range(0f,1f);
    		if (missedOrOut > 0.5f){
    			Run.text = "Missed";
    		}
    		else{
    			Run.text = "Out!";
    			batsmen -= 1;
    			Out.Play();
    		}
    	}
    	else{
    		score += run;

    	}
    	Bowling();

    }

    public void Bowling(){

    	if (balls > 1)
    	balls -= 1;
    	else
    	OverOver();

    	OABLeft.text = Overs + "." + balls + " overs left";
    	display.text = "Delivery type";
    	SecondPanel.SetActive(false);
    	FirstPanel.SetActive(true);
    }

    public void OverOver(){
    	if (Overs > 0){
    		balls = BallsPerOver;
    		Overs -= 1;
    	}
    	else{
    		GameOver();
    	}

    }

    public void Win(){
    	Debug.Log("Batsman win!");
    	Time.timeScale = 0f;
    	Application.Quit();
    }

    public void GameOver(){
    	Debug.Log("Bowlers win!");
    	Time.timeScale = 0f;
    	Application.Quit();
    }
}
