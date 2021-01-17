using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    int numerLekcji;

    private void Awake()
    {
        if(FindObjectsOfType<GameManger>().Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public int PobierzNrLekcji()
    {
        return numerLekcji;
    }
    public void PobierzNumerLekcjiZPrzycisku(int nrLekcji)
    {
        numerLekcji = nrLekcji;
        PrzelaczScene(1);
    }

    public void PrzelaczScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}