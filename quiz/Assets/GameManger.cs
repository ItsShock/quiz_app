using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    int numerLekcji;
    int iloscUkonczonychLekcji;

    private void Awake()
    {
        if(FindObjectsOfType<GameManger>().Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        if(!PlayerPrefs.HasKey("SaveUkonczonychlekcji"))
        {
            PlayerPrefs.SetInt("SaveUkonczonychlekcji", 0);
            iloscUkonczonychLekcji = 0;
        }
        else
        {
            iloscUkonczonychLekcji = PlayerPrefs.GetInt("SaveUkonczonychlekcji");
        }

    }

    public int PobierzIloscUkonczonychLekcji()
    {
        return PlayerPrefs.GetInt("SaveUkonczonychlekcji");
    }

    public void DodajUkonczonaLekcje()
    {
        iloscUkonczonychLekcji = PlayerPrefs.GetInt("SaveUkonczonychlekcji");
        iloscUkonczonychLekcji ++;
        PlayerPrefs.SetInt("SaveUkonczonychlekcji", iloscUkonczonychLekcji);
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

    public void ResteujIloscUkonczonychLekcji()
    {
        PlayerPrefs.SetInt("SaveUkonczonychlekcji", 0);
    }
}