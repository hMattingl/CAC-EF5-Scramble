using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerVariables
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
