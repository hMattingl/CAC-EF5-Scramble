using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStageOne : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private ColliderTest targetScriptReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 40 && targetScriptReference.InSafeZone())
            SceneManager.LoadScene("nextScene");
        else if (Time.time > 40 && targetScriptReference.InSafeZone()==false)
            SceneManager.LoadScene("GameOver");

    }
}
