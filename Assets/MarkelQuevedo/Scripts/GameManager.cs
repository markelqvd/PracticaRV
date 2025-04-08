using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // O "using UnityEngine.UI;" si usas el UI Text legacy

public class GameManager : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Cubes target: " + GameConfig.CubesTarget);
        Debug.Log("Two swords: " + GameConfig.TwoSwords);

        // Aqu� usar�as estos valores para ajustar tu l�gica:
        // - N�mero de cubos a generar
        // - Activar 1 o 2 sables
    }

public static GameManager instance;
    public int cubesDestroyed = 0;
    private int winThreshold = GameConfig.CubesTarget;

    // Si usas TextMeshPro:
    public TMP_Text scoreText;
    // Si usas UI Text legacy, usa: public Text scoreText;

    public GameObject winPanel;

    void Awake()
    {
        // Configuraci�n del Singleton
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
            Debug.LogWarning("Score Text no est� asignado en el GameManager");
        }

        if (cubesDestroyed >= winThreshold)
        {
            WinGame();
        }
    }

    public void BombDestroyed()
    {
        cubesDestroyed -= 1;
        if (scoreText != null)
        {
            scoreText.text = "Cubes Destroyed: " + cubesDestroyed;
        }
    }

    void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }
}


