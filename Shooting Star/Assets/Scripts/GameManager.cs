using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private ManagingScenes sceneManager;                       //Store a reference to our sceneManager which will set up the level.
    private string levelName2 = "WormHoleCaverns";                                  //Current level number
    private string levelName = "HomeStar";

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        sceneManager = GetComponent<ManagingScenes>();

        //Call the InitGame function to initialize the first level 
        InitGame();

        //BossEventManager.OnDeath += ChangeLevel;
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        sceneManager.SetupScene();

    }

    /*
    void ChangeLevel()
    {
        sceneManager.SetupScene(levelName);
        BossEventManager.OnDeath -= ChangeLevel;
    }
    */
    

}
