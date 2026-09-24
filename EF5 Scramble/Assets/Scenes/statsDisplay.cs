using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class statsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
    private int fear = 0;
    private bool hasRadio = false;
  
    // Update is called once per frame
    void Update()
    {
        //sets fear to 0 if it goes below 0
        if (fear < 0)
        {
            fear = 0;
        }

        //displays fear and other vars
        stats.text = " FEAR METER : " + fear + " has radio :" + hasRadio;

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
            fear -= 10;
        }
    }
}
