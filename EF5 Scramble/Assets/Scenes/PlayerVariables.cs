using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEditor;
public class PlayerVariables : MonoBehaviour
{
    public static void main()
    {
        //This costructs a player named Bob
        //It gives all of his stats, fear meter, hunger, and thirst. 
        //Is alive determines at the end of the round if the player character is still
        // or if you failed and you lose. 
        Player Bob = new Player();
        Bob.fearMeter = 0;
        Bob.hungry = false;
        Bob.thirsty = false;
        Bob.isAlive = true;

        //This constructs wife
        //She has the same stats as player character
        //DO WE WANT KIDS???
        //YESSSSSSS!!!!!
        //however the wife doesn't have to live for you to win the round. 
        Wife wife = new Wife();
        wife.fearMeter = 0;
        wife.hungry = false;
        wife.thirsty = false;
        wife.isAlive = true;

    }
}

    
public class Player : Variables
{
    
}


public class Variables 
{
    public int fearMeter;
    public Boolean hungry;
    public Boolean thirsty;
    public Boolean isAlive;


}

public class Wife : Variables
{
    
}
public class waterBottle : Variables
{
    public Button waterButton;
    public void drinkThatWater()
    {
        /*if(waterButton is clicked)*/
        {
            if (thirsty == true)
            {
                thirsty = false;
                EditorUtility.DisplayDialog("Status","You drank some water, you are no longer thirsty", "OK");
            }
            else
            {
                EditorUtility.DisplayDialog("Status", "You aren't thristy, you shouldn't waste water.", "OK");
            }
        }

    }

}
public class snackSupplies : Variables
{
    public Button snackButton;
    public void eatThatSnack()
    {
        /*if(snackButton is clicked)*/
        {
            if (hungry == true)
            {
                hungry = false;
                EditorUtility.DisplayDialog("Status", "You ate some food, you are no longer hungry", "OK");
            }
            else
            {
                EditorUtility.DisplayDialog("Status", "You aren't hungry, you shouldn't waste food.", "OK");
            }
        }
    }
}
