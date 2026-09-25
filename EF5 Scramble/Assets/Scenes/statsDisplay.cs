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
        stats.text = " FEAR METER : " + fear + " has radio :" + hasRadio;

        if (fear >= 100)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void ChangeFearMeter (int ammount)
    {
        fear = fear + ammount;
    }
}
