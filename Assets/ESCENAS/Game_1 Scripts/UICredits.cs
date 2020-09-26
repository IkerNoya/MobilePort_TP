using UnityEngine;
using UnityEngine.SceneManagement;

public class UICredits : MonoBehaviour
{
    public void OnClickMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
