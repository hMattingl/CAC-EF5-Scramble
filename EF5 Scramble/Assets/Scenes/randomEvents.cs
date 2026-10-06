using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor.PackageManager;

public class randomEvents : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI randomEventText;
    [SerializeField] private UnityEngine.UI.Button randomEventbutton;
    static bool doneRE = false;
    private int efLevel = 1;//Random.Range(1, 6);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomEventbutton.gameObject.SetActive(false);
       InvokeRepeating("tryRandomEvent",5,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (efLevel == 1 && statsDisplay.GetHours() == 3)
        {
            SceneManager.LoadScene("Win Screen");
        }
        else if (efLevel == 2 && statsDisplay.GetHours() == 4)
        {
            SceneManager.LoadScene("Win Screen");
        }
        else if (efLevel == 3 && statsDisplay.GetHours() == 5)
        {
            SceneManager.LoadScene("Win Screen");
        }
        else if (efLevel == 4 && statsDisplay.GetHours() == 6)
        {
            SceneManager.LoadScene("Win Screen");
        }
        else if (efLevel == 5 && statsDisplay.GetHours() == 7)
        {
            SceneManager.LoadScene("Win Screen");
        }
    }

        public void RandomEvent()
    {
        randomEventbutton.gameObject.SetActive(true);
        

        int rEvent;

        if (efLevel == 1)
        {
            rEvent = Random.Range(0, 2);
        }
        else if (efLevel == 2)
        {
            rEvent = Random.Range(2, 4);
        }
        else if (efLevel == 3)
        {
            rEvent = Random.Range(4, 6);
        }
        else if (efLevel == 4)
        {
            rEvent = Random.Range(6, 8);
        }
        else
        {
            rEvent = Random.Range(8, 10);
        }



        if (rEvent == 0)
        {
            randomEventText.text = "something happened";
            statsDisplay.ChangeFearMeter(10); 
        }
        else
        {
            randomEventText.text = "you heard a window shatter";
            statsDisplay.ChangeFearMeter(20);
        }

        Time.timeScale = 0;
        doneRE = true;

        
    }

     public void HideRE()
    {
        randomEventText.text = "";
        randomEventbutton.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
       
    public void tryRandomEvent()
    {
        if(!doneRE && Random.Range(1,101) > 66)
        {
            RandomEvent();
        }

        Debug.Log("tried");
    }

    public static void hourReset()
    {
        doneRE = false;
    }
}
