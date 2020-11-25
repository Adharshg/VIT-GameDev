using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text display;
	public Text Run;
	public GameObject FirstPanel;
	public GameObject SecondPanel;

	private string grid = "";
	private string bowler = "";
	private string delivery;

     // Start is called before the first frame update
    void Start()
    {
    	FirstPanel.SetActive(true);
    	SecondPanel.SetActive(false);
        display.text = "Delivery type";
    }

    void Update(){
    	if (grid != "" && bowler != ""){
    		Batting();
    	}
    }

    // Update is called once per frame
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
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 1:
    			if (chance < 0.9f){
    				Run.text = "1 runs";
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 2:
    			if (chance < 0.85f){
    				Run.text = "2 runs";
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 3:
    			if (chance < 0.6f){
    				Run.text = "3 runs";
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 4:
    			if (chance < 0.35f){
    				Run.text = "4 runs!";
    			}
    			else{
    				missed = true;
    			}
    			break;

    		case 6:
    			if (chance < 0.2f){
    				Run.text = "6 runs!!";
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
    		}
    	}
    	Bowling();

    }

    public void Bowling(){
    	display.text = "Delivery type";
    	SecondPanel.SetActive(false);
    	FirstPanel.SetActive(true);
    }
}
