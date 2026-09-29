using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class statsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
    private int fear = 0;
    private bool hasRadio = false;
    private int timePased = 0;
    private int efLevel;
    private void Start()
    {
        efLevel = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        timePased = (int)Time.time;
       

        //sets fear to 0 if it goes below 0
        if (fear < 0)
        {
            fear = 0;
        }

        //displays fear and other vars
        stats.text = " FEAR METER : " + fear + " has radio :" + hasRadio + timePased;

        //game over state
        if (fear >= 100)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void ChangeFearMeter (int ammount)
    {
        fear = fear + ammount;
    }

    public void RandomEvent()
    {
        int rEvent = Random.Range(0, 20);

        if (rEvent == 0)
        {
            fear += 10;
        }
        else
        {
            fear += 20;
        }
    }
}
