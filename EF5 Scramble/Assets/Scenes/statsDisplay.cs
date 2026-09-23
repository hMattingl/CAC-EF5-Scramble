using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class statsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
   // [SerializeField] int fearNum;
    private int fear = 0;
    private bool hasRadio = false;
  
    // Update is called once per frame
    void Update()
    {
        stats.text = " FEAR METER : " + fear + " has radio :" + hasRadio;
       
        if (fear >= 100)
        {
            int dataToKeep = fear;
            StaticData.valueToKeep = dataToKeep; 
           
            SceneManager.LoadScene("GameOver");
            
        }

    }

    public void ChangeFearMeter (int ammount)
    {
        fear = fear + ammount;
    }
}
