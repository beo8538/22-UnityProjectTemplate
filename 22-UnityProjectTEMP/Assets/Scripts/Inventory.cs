/**** 
 * Created by: Betzaida Ortiz Rivas
 * Date Created: March 2, 2022
 * 
 * Last Edited by: N/A
 * Last Edited:
 * 
 * Description: Updated the players inventory
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory")]

public class Inventory : ScriptableObject
{
    [SerializeField] int keycards = 0; //keycards the player has
    public int GetKeyCards { get => keycards; } //gets keycards
    public void UpdateKeyCards(int numKeyCards) { keycards += numKeyCards; } //Updates the keycards player has on hand

    public int flashlight = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
