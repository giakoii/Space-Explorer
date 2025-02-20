using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunction : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GamePlay1");
    }
    public void Exit()
    {
     Application.Quit();
    }
    public void Instruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void ExitMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
