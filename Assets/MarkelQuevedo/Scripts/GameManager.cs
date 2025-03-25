using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // O "using UnityEngine.UI;" si usas el UI Text legacy

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int cubesDestroyed = 0;
    public int winThreshold = 30;

    // Si usas TextMeshPro:
    public TMP_Text scoreText;
    // Si usas UI Text legacy, usa: public Text scoreText;

    public GameObject winPanel;

    void Awake()
    {
        // Configuración del Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        winPanel.SetActive(false);
    }

    public void CubeDestroyed()
    {
        cubesDestroyed++;
        if (scoreText != null)
        {
            scoreText.text = "Cubes Destroyed: " + cubesDestroyed;
        }
        else
        {
            Debug.LogWarning("Score Text no está asignado en el GameManager");
        }

        if (cubesDestroyed >= winThreshold)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }
}


