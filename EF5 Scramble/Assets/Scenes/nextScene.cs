using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public void LoadSceneByName(string name)
    {
        name = "SampleScene";
        SceneManager.LoadScene(name);
    }
}
