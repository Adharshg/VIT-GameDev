using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text display;

	private string grid = "";
	private string bowler = "";

     // Start is called before the first frame update
    void Start()
    {
        display.text = "Delivery type";
    }

    void Update(){
    	if (grid != "" && bowler != ""){
    		display.text = bowler + " grid " + grid;
    	}
    }

    // Update is called once per frame
    public void SelectGrid(Button button1){
        grid = "" + button1.name;
    }

    public void SelectBowler(Button button2){
    	bowler = "" + button2.name;

    }
}
