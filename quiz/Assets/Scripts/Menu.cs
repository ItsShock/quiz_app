using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject btnPrefab;
    [SerializeField] Transform prefabRodzic;
    [SerializeField] GameObject PanelUstawien;
    int iloscWszystkichDostepnychLekcji = 5;
    void Start()
    {
        StworzPrzyciskiWyborulekcji();
    }

    void StworzPrzyciskiWyborulekcji()
    {
        for(int i = 0; i < iloscWszystkichDostepnychLekcji; i++)
        {
            GameObject btn = Instantiate(btnPrefab, prefabRodzic);
            btn.GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
    }
 
    public void ResteujPlayerprefs()
    {
        FindObjectOfType<GameManger>().ResteujIloscUkonczonychLekcji();
        FindObjectOfType<GameManger>().ResteujNrZadania();
        FindObjectOfType<Punkty>().ResetujIloscPkt();
        FindObjectOfType<Punkty>().ResetujIloscPktwAktualnejLekcji();
        SceneManager.LoadScene(0);
    }

    public void OdkryjPanelUstawien(bool odkryj)
    {
        PanelUstawien.SetActive(odkryj);
    }

    public void ZamknijProgram()
    {
        Application.Quit();
    }
}

