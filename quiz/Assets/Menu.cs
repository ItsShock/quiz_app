using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject btnPrefab;
    [SerializeField] Transform prefabRodzic;
    int iloscWszystkichDostepnychLekcji = 3;
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
        FindObjectOfType<Punkty>().ResetujIloscPkt();
    }
}
