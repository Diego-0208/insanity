using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;

    void Awake()
    {
        // Asegúrate de que solo hay una instancia del ScoreManager
        if (FindObjectsOfType<ScoreManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void AddPoints(int points)
    {
        score += points;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }
}