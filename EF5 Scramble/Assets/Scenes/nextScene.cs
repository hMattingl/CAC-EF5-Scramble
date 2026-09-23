using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextScene : MonoBehaviour
{
    public void LoadSceneByName(string name)
    {

        
        
        SceneManager.LoadScene(name);
     
    }

    public void MoveButton(int amount)
    {
        RectTransform rt = GetComponent<RectTransform>();

        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y + amount);
        
    }
}
