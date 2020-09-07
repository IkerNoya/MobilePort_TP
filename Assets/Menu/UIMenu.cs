using Boo.Lang;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] Transform[] buttonsPos;
    [SerializeField] GameObject menuPointer;
    [SerializeField] float rotatePointer = 20;
    void Start()
    {
        menuPointer.transform.position = new Vector3(menuPointer.transform.position.x, buttonsPos[0].position.y, menuPointer.transform.position.z);
    }
    void Update()
    {
        menuPointer.transform.Rotate(0, rotatePointer, 0);
    }
    public void ChangeScene(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        Debug.Log("Loading " + sceneName);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
