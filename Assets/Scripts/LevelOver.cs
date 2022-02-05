using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOver : MonoBehaviour
{
    public Button ButtonRestart;
    public Button buttonExit;

    public void Awake()
    {
        ButtonRestart.onClick.AddListener(ReloadLevel);
        buttonExit.onClick.AddListener(ExitGame);

    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        Debug.Log("Reloading Scene 0");
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
