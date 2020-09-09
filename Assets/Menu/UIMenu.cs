using UnityEngine;
using UnityEngine.EventSystems;


public class UIMenu : MonoBehaviour
{
    [SerializeField] Transform[] buttonsPos;
    [SerializeField] GameObject[] menuAnim;
    [SerializeField] float rotatePointer = 20;
    [SerializeField] GameObject playButton;
    void Start()
    {
        for (int i = 0; i < menuAnim.Length; i++)
            if (menuAnim[i] != null)
                menuAnim[i].transform.position = new Vector3(menuAnim[i].transform.position.x, buttonsPos[0].position.y, menuAnim[i].transform.position.z); 
    }
    void Update()
    {
        for (int i = 0; i < menuAnim.Length; i++)
            if (menuAnim[i] != null)
                menuAnim[i].transform.Rotate(0, rotatePointer, 0);

        if (EventSystem.current.currentSelectedGameObject != null)
            return;
        EventSystem.current.SetSelectedGameObject(playButton);
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
