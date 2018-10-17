using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class LevelController : MonoBehaviour {

    //fields for sound in the level
    [SerializeField]
    private AudioSource soundMain;
    [SerializeField]
    private AudioClip tapIncrementSound;

    //End Screen Text and objects (defined in unity during edit mode)
    [SerializeField]
	private GameObject EndLevelScreen ;
	[SerializeField]
	private Text LevelCompleteText;
	[SerializeField]
	private Text messageText;
	[SerializeField]
	private Text RewardText;
	[SerializeField]
	private GameObject MessageObj;
	[SerializeField]
	private int Reward;
	[SerializeField]
	private Text buttonText;
	[SerializeField]
	private GameObject InfoObj;
	[SerializeField]
	private string[] InfoList;
	[SerializeField]
	private Text infoText;

    //Information display index and object to disable 
    //when instructions are finished
	[SerializeField]
	private int currInfoNum;
	[SerializeField]
	private GameObject screenTap;

	[SerializeField]
	private GameObject car;
	[SerializeField]
	
    //the GameObjects which the MinigameController subclasses
    //are attached to
	private GameObject[] Controller;
    [SerializeField]
    private GameObject correctEnd;
    [SerializeField]
    private GameObject incorrectEnd;
    [SerializeField]
    private bool GameEnded;

    //Win and lose conditions and their corresponding 
    //UI elements
    [SerializeField]
    public Image[] lives;
    [SerializeField]
    private Text winCondition;
    [SerializeField]
    public int livesLeft = 3;
    [SerializeField]
    public int winLeft = 15;

    //Runs when the object loads
	void Start () {
        //sets the current levelcontroller referenced by GameController to this class when the scene loads
        transform.parent = GameController.controller.transform;
        GameController.thisLevelController = this;
	}



    //Ends the current level
    //LevelMessage sets a message to be displayed at the end
    //The boolean win indicates whether we have won or not
	public void EndLevel(bool Win, string levelMessage){
        if (!GameEnded)
        {
            GameEnded = true;
            //Win screen
            if (Win)
            {
                LevelCompleteText.text = "Level Complete!";
                RewardText.text = "You Earned: " + Reward.ToString() + "Points";
                messageText.text = levelMessage;
                //MessageObj.SetActive (true);
                buttonText.text = "Next Level >";
                correctEnd.SetActive(true);
            }
            //Lose Screen
            else
            {
                LevelCompleteText.text = "Level failed!";
                RewardText.text = "Try Again";
                messageText.text = levelMessage;
                //MessageObj.SetActive (false);
                buttonText.text = "Retry Level >";
                incorrectEnd.SetActive(true);
            }
          //Tell the minigame controller to stop running the game
            foreach (GameObject g in Controller)
            {
                g.GetComponent<MinigameController>().EndGame();
            }
            //screenTap.SetActive (true);  
        }
	}

    //Handles the information text before each minigame
	public void ScreenTapIncrement(){
		if(InfoList.Length <= currInfoNum){
	
            //disable the information visual objects
			InfoObj.SetActive (false);
            //disable the screen tap incrementer UI element
			screenTap.SetActive (false);
            foreach (GameObject g in Controller)
            {
                g.GetComponent<MinigameController>().StartGame();
            }
        }
		else{
			infoText.text = InfoList [currInfoNum];
			currInfoNum++;
		}
        //Play the sound for tapping the screen pre-game
        soundMain.PlayOneShot(tapIncrementSound);
	}


    //Deduct a life and determine if the game should end
   public void loseLifeNow()
    {
        int index = 0;
        foreach(Image i in lives)
        {
            if (index <= livesLeft -1)
            {
                i.gameObject.SetActive(true);
            }
            else
            {
                i.gameObject.SetActive(false);
            }
            index++;
        } 
        if(livesLeft <= 0)
        {
            EndLevel(false, "You lost!");
        }
    }

    //Set the win condition for a new game
    public void setWinCondition(int winInt)
    {
        winLeft = winInt;
        winCondition.text = winLeft.ToString();
    }
    

}

