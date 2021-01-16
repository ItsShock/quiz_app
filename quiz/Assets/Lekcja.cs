using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lekcja : MonoBehaviour
{
    
    [SerializeField] Text txtTrescZad;
    [SerializeField] Text txtNrZad;
    [SerializeField] Button[] przyciskiOdp;
    int numerZad = 0;
    [SerializeField] Zadanie[] zadania;
    Punkty pktskrytp;
    int ileJestOdpWZadaniu;
    string odpUzytkownika;
    void Start()
    {
        pktskrytp = FindObjectOfType<Punkty>();
        TworzNoweZad();
        WyswietlNrZad();
    }

    void PrzypiszElementyDoZad()
    {
        txtTrescZad.text = zadania[numerZad].PobierzTrescZad();
    }

    void OdkryjPrzyciskiOdp()
    {
    for (int i = 0; i < ileJestOdpWZadaniu; i++)
        {
            przyciskiOdp[i].gameObject.SetActive(true);
        }
    }
    void TworzNoweZad()
    {
        UkryjWszystkiePrzyciskiOdp();
        SprawdzIleJestOdpWZad();
        OdkryjPrzyciskiOdp();
        PrzypiszElementyDoZad();
        PrzypiszWartosciDoPrzyciskow();
        WyswietlNrZad();
    }

    void SprawdzIleJestOdpWZad()
    {
        ileJestOdpWZadaniu = 0;
        for (int i = 0; i < 3; i++)
        {
            if(zadania[numerZad].PobierzZlaOdp(i + 1) != "")
            {
                ileJestOdpWZadaniu ++;
            }
        }
        ileJestOdpWZadaniu ++;
        print("ilosc odpowiedzi w zadaniu: " + ileJestOdpWZadaniu);
    }

    void PrzypiszWartosciDoPrzyciskow()
    {
        List<string> listaOdp = new List<string>();
        for(int i = 0; i < ileJestOdpWZadaniu; i++)
        {
            if(i == 0)
            {
                listaOdp.Add(zadania[numerZad].PobierzPrawidlowaOdp());
            }
            else
            {
                listaOdp.Add(zadania[numerZad].PobierzZlaOdp(i));
            }
        }

        int j = 0;
        for(int i = listaOdp.Count; i > 0; i--)
        {
            int rand = Random.Range(0, listaOdp.Count);
            przyciskiOdp[j].GetComponentInChildren<Text>().text = listaOdp[rand];
            listaOdp.RemoveAt(rand);
            j++;
        }                
    }

    void UkryjWszystkiePrzyciskiOdp()
    {
        for (int i = 0; i < przyciskiOdp.Length; i++)
        {
            przyciskiOdp[i].gameObject.SetActive(false);
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

    void WyswietlNrZad()
    {
        txtNrZad.text = "Numer zadania: " + numerZad;
    }

    void Update()
    {
        
    }
}
