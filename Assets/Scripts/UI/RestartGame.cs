using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectButton;

    private void Start()
    {
        Events.OnDeadedPlayer += EnableButton;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    private void EnableButton()
    {
        gameObjectButton.SetActive(true);
    }

    private void OnDestroy()
    {
        Events.OnDeadedPlayer -= EnableButton;
    }
}
