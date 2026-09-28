using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

public class PlayerVariables : MonoBehaviour
{
    private int fearMeter;

    public int getFearMeter()
    {
        return fearMeter;
    }
    public void addFearMeter()
    {
        fearMeter = fearMeter + 10;
    }
    public void faceFears()
    {
        fearMeter = fearMeter - 10; 
    }
    

}





