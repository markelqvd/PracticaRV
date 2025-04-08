using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuConfigManager : MonoBehaviour
{
    public Dropdown cubeDropdown;  // Dropdown para seleccionar el número de cubos
    public Toggle twoSwordsToggle;      // Toggle para seleccionar uno o dos sables

    private void Start()
    {
        // Iniciar el dropdown y toggle con los valores actuales de GameConfig
        cubeDropdown.value = GameConfig.CubesTarget / 10 - 1; // Suponiendo que tienes opciones de 10, 20, 30
        twoSwordsToggle.isOn = GameConfig.TwoSwords;
    }

    public void OnDropdownChanged()
    {
        GameConfig.CubesTarget = int.Parse(cubeDropdown.options[cubeDropdown.value].text);
    }

    public void OnToggleChanged()
    {
        GameConfig.TwoSwords = twoSwordsToggle.isOn;
    }
}
