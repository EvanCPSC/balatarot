using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void OnStartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnOptionsClick()
    {
        
    }

    public void OnQuitClick()
    {
        // BloodBTF. "How do I create a Exit/Quit Button", Unity Discussions, Jun. 2015, https://discussions.unity.com/t/how-do-i-create-a-exit-quit-button/142125.
        Application.Quit();
        Debug.Log("Game is exiting");
        // ------------
    }
}
