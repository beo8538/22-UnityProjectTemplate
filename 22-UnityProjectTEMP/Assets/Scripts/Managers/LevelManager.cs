/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Basic level manager
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /*** VARIABLES ***/

    GameManager gm; //reference to game manager

    [Header("LEVEL SETTINGS")]
    public Camera mainCamera; //reference to main camera
    public GameObject playerCharacter; //reference to player character
    [Space(10)]

    [Tooltip("Can the level be beat by a score")]
    public bool canBeatLevel = false; //can the level be beat by a score
    public int beatLevelScore; // the score value to beat level
    [Space(10)]

    [Tooltip("Is the level timed")]
    public bool timedLevel = false; //is the leve timed 
    public float startTime = 5.0f; //time for level (if level is timed)
    [Space(10)]

    [Tooltip("Are there collectables")]
    public bool collectableLevel = false; //is the leve timed 
  

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.GM; //find the game manager

        if (mainCamera == null) { mainCamera = Camera.main; } //if main camera is null set to the default main camera
        if(playerCharacter == null) { playerCharacter = GameObject.FindGameObjectWithTag("Player"); } //set the player if null

        if (timedLevel) { StartTimer(); } //start timer if level is timed
    }//end Start();


    // Update is called once per frame
    private void Update()
    {
        Debug.Log(beatLevelScore);
        if (canBeatLevel) { CheckScore(); }
    }//end Update()


        private void StartTimer()
    {

    }//end StartTimer();

    private void CheckScore()
    {
        if(gm.Score >= beatLevelScore)
        {
            gm.nextLevel = true;
        }
    }





}
