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

    [Tooltip("Can the level be beat by a score")]
    public bool canBeatLevel = false; //can the level be beat by a score
    public int beatLevelScore; // the score value to beat level
    [Space(10)]

    [Tooltip("Is the level timed")]
    public bool timedLevel = false; //is the leve timed 
    public float startTime = 5.0f; //time for level (if level is timed)
    [Space(10)]

    [Tooltip("Aret there collectables")]
    public bool collectableLevel = false; //is the leve timed 
   // public float startTime = 5.0f; //time for level (if level is timed)


    private void Start()
    {
        gm = GameManager.GM; //find the game manager
    }

}
