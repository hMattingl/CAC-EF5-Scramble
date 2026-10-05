using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class statsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
    static int fear = 0;
    private bool hasBoardGame = false;
    private bool doneBoardGame = false;
    private int timePased = 0;
    private int hour = 1;
    
    
    
    private void Start()
    {  
        fear = 0;    
    }

    // Update is called once per frame
    void Update()
    {    
        

        //displays fear and other vars
        stats.text = " FEAR METER : " + fear + "     Time passed: " + hour + " hours";
        
        //sets fear to 0 if it goes below 0
        if (fear < 0)
        {
            fear = 0;
        }
        
        timePased = (int)Time.time;

        if (hour * 60 == timePased)
        {
            hour++;
            randomEvents.hourReset();
            Radiothings.hourReset();

        }
            
        //game over state
        if (fear >= 100)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public static void ChangeFearMeter(int ammount)
    {
        fear += ammount;
    }


   
}    

        


    

