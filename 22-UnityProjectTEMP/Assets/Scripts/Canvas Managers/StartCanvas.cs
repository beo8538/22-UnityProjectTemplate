/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //libraries for UI components

public class StartCanvas : MonoBehaviour
{
    /*** VARIABLES ***/
   
    GameManager gm; //reference to game manager

    [Header("Canvas SETTINGS")]
    public Text titleTextbox;
    public Text creditsTextbox;
    public Text copyrightTextbox;

    private void Start()
    {
         gm = GameManager.GM; //find the game manager
         titleTextbox.text = gm.gameTitle;
         creditsTextbox.text = gm.gameCredits;
         copyrightTextbox.text = gm.copyrightDate;
    }

}
