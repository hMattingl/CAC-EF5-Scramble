using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Radiothings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI radio;
    [SerializeField] private UnityEngine.UI.Button radioButton;
    private bool hasRadio = false;
    static bool doneRadio = false;
    private string radiotxt = "";
    private int radioRandom = 0;
    private int textpopupTimer = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doneRadio = false;
    }


    public void UseRadio()
    {
        
        
        int radioRandom = Random.Range(0,2);

        if (radioRandom == 0)
        {
        radiotxt = "good thing may happen";
        statsDisplay.ChangeFearMeter(-10);
        }
        else
        {
        radiotxt = "bad thing may happened";
        statsDisplay.ChangeFearMeter(10);
        }
        
        
        radio.text = radiotxt;

        doneRadio = true;

    }

       public void HideR()
    {
        radio.text = "";
    }

    public static void hourReset()
    {
        doneRadio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(radio.text != "")
        {
            Invoke("HideR", 3);
        }

        if(doneRadio)
        {
            radioButton.interactable = false;
        }
        else
        {
            radioButton.interactable = true;
        }

    }
}
