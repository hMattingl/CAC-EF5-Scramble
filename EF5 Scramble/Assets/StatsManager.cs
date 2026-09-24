using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Experimental.GlobalIllumination;

public class StatsManager : MonoBehaviour
{
    [Header("Player Stats")]


    [Header("Spouse Stats")]
    public int num;
}
//This is the stats that will be shared between all of the characters. The player, the children, and the spouse.
public class variables
{
    public int fearMeter;
    private Boolean isAlive;
}
public class player : variables
{

}
public class children : variables
{
    private int numOfChildren;
}
public class spouse : variables
{

}
public class CharacterVariables
{
    public static void main()
    {
        player main = new player();
        main.fearMeter = 0; 


    }
}