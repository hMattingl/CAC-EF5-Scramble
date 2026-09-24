using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int myScore = Static.valueToKeep;
        score.text = "" + myScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
