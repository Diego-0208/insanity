using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    void RestartGame()
    {
        GameManager.Instance.RestartLevel(); // Llama al método para reiniciar el nivel
    }

    void LoadMainMenu()
    {
        GameManager.Instance.ResetGame(); // Llama al método para volver al menú principal
    }
}
