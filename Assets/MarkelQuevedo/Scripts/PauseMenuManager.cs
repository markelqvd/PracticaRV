using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    // Referencia al panel del menú de pausa (asegúrate de asignarlo desde el Inspector)
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
        // En VR deberás mapear el botón del mando que corresponda.
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

    // Reanuda el juego: oculta el menú y restablece Time.timeScale
    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    // Pausa el juego: muestra el menú y detiene la simulación
    public void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    // Se llama al pulsar el botón "Volver al menú" del menú de pausa
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Restauramos Time.timeScale para no afectar la nueva escena
        SceneManager.LoadScene("Menu"); // Asegúrate de tener una escena llamada "MainMenu"
    }
}
