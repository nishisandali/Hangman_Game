using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //Keep track of the GameController
	public static GameController controller;
    //Keep track of the current level controller
    public static LevelController thisLevelController;



	void Awake () {
        //Already have controller?
        if(controller == null)
             controller = this;
        DontDestroyOnLoad (this.gameObject);

	}
	
	
    //Change the level to new Level(int)
    //integer represents the build number of the scene
    //this is defined in the editor
	public void GoToLevel(int Level){
		SceneManager.LoadScene(Level, LoadSceneMode.Single);
    }

    //Exits the application
	public void ExitApplication(){
		Application.Quit ();
	}
}
