using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class statsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
    [SerializeField] private TextMeshProUGUI radio;
    [SerializeField] private TextMeshProUGUI randomEventText;
    private int fear = 0;
    private bool hasBoardGame = false;
    private bool hasRadio = false;
    private int timePased = 0;
    private int efLevel;
    private string radiotxt;
    private int radioRandom = 0;
    private int hour;

    private void Start()
    {
        efLevel = Random.Range(1, 6);

    }

    // Update is called once per frame
    void Update()
    {
        timePased = (int)Time.time;

        if (hour * 60 == timePased)
            hour++;



        //sets fear to 0 if it goes below 0
        if (fear < 0)
            fear = 0;

        //displays fear and other vars
        stats.text = " FEAR METER : " + fear + "    Time passed: " + hour + " hours";

        //game over state
        if (fear >= 100)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void ChangeFearMeter(int ammount)
    {
        fear = fear + ammount;
    }

    public void RandomEvent()
    {
        int rEvent;

        if (efLevel == 1)
        {
            rEvent = Random.Range(0, 3);
        }
        else if (efLevel == 2)
        {
            rEvent = Random.Range(3, 7);
        }
        else if (efLevel == 3)
        {
            rEvent = Random.Range(7, 13);
        }
        else if (efLevel == 4)
        {
            rEvent = Random.Range(13, 17);
        }
        else
        {
            rEvent = Random.Range(17, 21);
        }



        if (rEvent == 0)
        {
            fear += 10;
            randomEventText.text = " window Crashed";
        }
        else
        {
            fear += 20;

        }


        
    }

    public void UseRadio()
    {
        radiotxt = "test text";

        radio.text = radiotxt;


    }
    
       


}    

        


    

