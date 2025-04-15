using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    // Referencia al panel del men� de pausa (aseg�rate de asignarlo desde el Inspector)
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Start()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Para pruebas en el editor: detectamos la tecla Escape.
        // En VR deber�s mapear el bot�n del mando que corresponda.
        if (Input.GetKeyDown(KeyCode.G))
        {
            TogglePause();
        }
    }

    // Alterna el estado de pausa
    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    // Reanuda el juego: oculta el men� y restablece Time.timeScale
    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    // Pausa el juego: muestra el men� y detiene la simulaci�n
    public void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    // Se llama al pulsar el bot�n "Volver al men�" del men� de pausa
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Restauramos Time.timeScale para no afectar la nueva escena
        SceneManager.LoadScene("Menu"); // Aseg�rate de tener una escena llamada "MainMenu"
    }
}
