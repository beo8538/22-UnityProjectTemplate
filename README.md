# UnityProject-Template
 Basic Unity Git Repository Template with GameManager

This project template includes the following: 
 
 - GIT Large File Storage (LFS) capbilities : https://docs.github.com/en/repositories/working-with-files/managing-large-files/installing-git-large-file-storage
    - To setup from scratch the .gitattributes must be set
  
  - YAMLMerge version control for merting scene and prefabs - https://learn.unity.com/tutorial/working-with-yamlmerge#5feba6a2edbc2a69e6450f9e
    - To setup from scratch note that Asset Serialization is now under Editor settings
    
  - Scenes : The project incldues the following default scenes
    - Start : main menu with title
    - Game Over : restart button and game over status
    - Level_00 : sample secene, first playable game level
    - Level_01 : sample scene, second playable game level
    
  - Game Manager: The game manger is setup with the following features:
   - General game settings
   - Game settings: score, lives, possible beatl level and timer
   - Game states : Idle, Playing, Death, GameOver, BeatLevel
   - StartGame() : starts and restarts game as it sets all the defaults
   - GameOver() : calls the game over scene 
   - ExitGame(): exits the game 
   - NextLevel(): loads the apporiate next game level 

  - Canvas Manager: one for each game canvas to control the displayed content
     - StartCanvas
     - EndCanvas
  
   
