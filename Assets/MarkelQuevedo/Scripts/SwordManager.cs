using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    public GameObject leftSword;
    public GameObject rightSword;

    void Start()
    {
        if (GameConfig.TwoSwords)
        {
            leftSword.SetActive(true);
            rightSword.SetActive(true);
        }
        else
        {
            leftSword.SetActive(false);
            rightSword.SetActive(true);
        }
    }
}
