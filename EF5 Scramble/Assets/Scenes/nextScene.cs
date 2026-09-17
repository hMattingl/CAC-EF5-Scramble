using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextScene : MonoBehaviour
{
    public void LoadSceneByName(string name)
    {

        
        name = "SampleScene";
        SceneManager.LoadScene(name);
     
    }

    public void MoveButton(int amount)
    {
        RectTransform rt = GetComponent<RectTransform>();
        amount = 20;

        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y + amount);
        
    }
}
