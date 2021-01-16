using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lekcja : MonoBehaviour
{
    
    [SerializeField] Text txtTrescZad;
    [SerializeField] Button[] przyciskiOdp;
    int numerZad = 0;
    [SerializeField] Zadanie[] zadania;
    Punkty pktskrytp;
    string odpUzytkownika;
    void Start()
    {
        pktskrytp = FindObjectOfType<Punkty>();
        TworzNoweZad();
    }

    void PrzypiszElementyDoZad()
    {
        txtTrescZad.text = zadania[numerZad].PobierzTrescZad();
    }

    void TworzNoweZad()
    {
        PrzypiszElementyDoZad();
        PrzypiszWartosciDoPrzyciskow();
    }

    void PrzypiszWartosciDoPrzyciskow()
    {
        int losowaLiczba = Random.Range(0,4);
        przyciskiOdp[losowaLiczba].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzPrawidlowaOdp();
        if(losowaLiczba == 0)
        {
            przyciskiOdp[losowaLiczba + 1].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(1);
            przyciskiOdp[losowaLiczba + 2].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(2);
            przyciskiOdp[losowaLiczba + 3].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(3);
        }
        else if(losowaLiczba == 1)
        {
            przyciskiOdp[losowaLiczba - 1].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(3);
            przyciskiOdp[losowaLiczba + 1].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(1);
            przyciskiOdp[losowaLiczba + 2].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(2);
        }
        else if(losowaLiczba == 2)
        {
            przyciskiOdp[losowaLiczba - 2].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(2);
            przyciskiOdp[losowaLiczba - 1].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(1);
            przyciskiOdp[losowaLiczba + 1].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(3);
        }
        else
        {
            przyciskiOdp[losowaLiczba - 3].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(1);
            przyciskiOdp[losowaLiczba - 2].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(3);
            przyciskiOdp[losowaLiczba - 1].GetComponentInChildren<Text>().text = zadania[numerZad].PobierzZlaOdp(2);
        }
        
    }

    public void PobierzOdpUzytkownika(string odp) 
    {
        odpUzytkownika = odp;

    }

    public void SprawdzOdp()
    {
        if(odpUzytkownika == zadania[numerZad].PobierzPrawidlowaOdp())
        {
            print("Odp poprawna");
            pktskrytp.DodajPkt(1);
            PrzelaczNastepneZad();

        }
        else
        {
            print("Odp niepoprawna");
        }
    }

    void PrzelaczNastepneZad()
    {
        if(numerZad < zadania.Length -1)
        {
            numerZad ++;
            TworzNoweZad();
        }
        else
        {
            numerZad = 0;
            TworzNoweZad();
        }
    }

    void Update()
    {
        
    }
}
