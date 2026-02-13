using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void OnButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
