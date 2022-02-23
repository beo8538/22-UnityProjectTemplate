/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Basic GameManager Template
****/

/** Import Libraries **/
using System; //C# library for system properties
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //libraries for accessing scenes
using UnityEngine.UI; //libraries for UI components


public class GameManager : MonoBehaviour
{
    /*** VARIABLES ***/

    #region GameManager Singleton
    static private GameManager gm; //refence GameManager
    static public GameManager GM { get { return gm; } } //public access to read only gm 

    //Check to make sure only one gm of the GameManager is in the scene
    void CheckGameManagerIsInScene()
    {
    
        //Check if instnace is null
        if (gm == null)
        {
           gm = this; //set gm to this gm of the game object
            Debug.Log(gm);
        }
        else //else if gm is not null a Game Manager must already exsist
        {
            Destroy(this.gameObject); //In this case you need to delete this gm
        }
        DontDestroyOnLoad(this); //Do not delete the GameManager when scenes load
        Debug.Log(gm);
    }//end CheckGameManagerIsInScene()
    #endregion

    [Header("GENERAL SETTINGS")]
    public string gameTitle = "Untitled Game";  //name of the game
    public string gameCredits = "Made by Me"; //game creator(s)
    public string copyrightDate = "Copyright " + thisDay; //date cretaed
   

    [Header("GAME SETTINGS")]

    [Tooltip("Can the level be beat by a score")]
    public bool canBeatLevel = false; //can the level be beat by a score
    public int beatLevelScore; // the score value to beat level
    
    [Space(10)]
    
    //static vairables can not be updated in the inspector, however private serialized fileds can be
    [SerializeField] //Access to private variables in editor
    private int numberOfLives; //set number of lives in the inspector
    public static int lives; // number of lives for player 
    public int Lives { get { return lives; } set { lives = value; } }//access to private variable died [get/set methods]

    public static int score;  //score value
    public int Score { get { return score; } set { score = value; } }//access to private variable died [get/set methods]

    [SerializeField] //Access to private variables in editor
    [Tooltip("Check to test player dead functions")]
    private bool died = false;//player has died
    public bool Died { get { return died; } set { died = value; } } //access to private variable died [get/set methods]

    [Space(10)]
    public string looseMessage = "You Loose"; //Message if player looses
    public string winMessage = "You Win"; //Message if player wins

    [Space(10)]

    [Tooltip("Is the level timed")]
    public bool timedLevel = false; //is the leve timed 
    public float startTime = 5.0f; //time for level (if level is timed)

    [Header("SCENE SETTINGS")]
    [Tooltip("Name of the start scene")]
    public string startScene;
    [Tooltip("Name of the game over scene")]
    public string gameOverScene;
    [Tooltip("Count and name of each Game Level (scene)")]
    public string[] gameLevels;
    public static int currentScene = 0; //the current level id



    //Game State Varaiables
    [HideInInspector] public enum gameStates { Idle, Playing, Death, GameOver, BeatLevel };//enum of game states
    [HideInInspector] public gameStates gameState = gameStates.Idle;//current game state
    [HideInInspector] public bool gameIsOver = false;//is the game over

    //Timer Varaibles
    private float currentTime; //sets current time for timer
    private bool gameStarted = false; //test if games has started
 
    private static string thisDay = System.DateTime.Now.ToString("yyyy"); //today's date as string
   // public bool firstLevel = true;


    /*** MEHTODS ***/
    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        //runs the method to check for the GameManager
        CheckGameManagerIsInScene();

        //store the current scene
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);

    }//end Awake()

    private void Update()
    {
        //if ESC is pressed , exit game
        if (Input.GetKey("escape")) { ExitGame(); }

        //if we are playing the game
        if (gameState == gameStates.Playing)
        {
            //if we have died and have no more lives, go to game over
            if (Died && (Lives == 0)) { GameOver(); }

        }//end if (gameState == gameStates.Playing)

    }


    //load first game level (level 1)
   public void StartGame()
    {
        SceneManager.LoadScene(gameLevels[0]); //load first game level

        gameState = gameStates.Playing; //set the game state to playing

        Lives = numberOfLives; //set the number of lives
        score = 0; //set starting score
    }//end StartGame()


    //exit the game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited Game");
    }//end ExitGame()


    //got to game over scene
    public void GameOver()
    {
        gameState = gameStates.GameOver; //set the game state to gameOver
        SceneManager.LoadScene(gameOverScene); //load the game over scene
        Debug.Log("Gameover");
    }

}
