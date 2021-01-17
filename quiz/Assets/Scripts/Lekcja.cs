using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lekcja : MonoBehaviour
{
    [SerializeField] GameObject panelUkonczeniaLekcji;
    [SerializeField] Text txtTrescZad;
    [SerializeField] Text txtNrZad;
    [SerializeField] Text txtNrLekcji;
    [SerializeField] Text txtPkt;
    [SerializeField] Button[] przyciskiOdp;
    int numerZad;
    int numerLekcji = 0;
    [SerializeField] Zadanie[] zadaniaLekcja0;
    [SerializeField] Zadanie[] zadaniaLekcja1;
    [SerializeField] Zadanie[] zadaniaLekcja2;
    [SerializeField] Image imgZdjecieDoZad;

    Zadanie[] zadaniaAktualnejLekcji;
    Punkty pktskrytp;
    GameManger gm;
    SoundManager sm;
    int ileJestOdpWZadaniu;
    string odpUzytkownika;
    void Start()
    {
        gm = FindObjectOfType<GameManger>();
        sm = FindObjectOfType<SoundManager>();
        numerLekcji = gm.PobierzNrLekcji();
        UstawLekcje(numerLekcji - 1);
        pktskrytp = FindObjectOfType<Punkty>();

        if(numerLekcji == gm.PobierzIloscUkonczonychLekcji())
        {
            numerZad = gm.PobierzNrZadania();
        }
        else
        {
            numerZad = 0;
        }

        TworzNoweZad();
        WyswietlNrZad();
        WyswietlIloscPkt();
        //print(numerLekcji);
        //print(gm.PobierzIloscUkonczonychLekcji());
    }

    void UstawLekcje(int nrLekcji)
    {
        numerLekcji = nrLekcji;
        txtNrLekcji.text = "Lekcja: " + nrLekcji + 1;
        switch(nrLekcji)
        {
            case 0:
                zadaniaAktualnejLekcji = zadaniaLekcja0;
                break;
            case 1: 
                zadaniaAktualnejLekcji = zadaniaLekcja1;
                break;
            case 2: 
                zadaniaAktualnejLekcji = zadaniaLekcja2;
                break;
            default:
                zadaniaAktualnejLekcji = zadaniaLekcja0;
                break;
        }
    }
        void WyswietlIloscPkt()
    {
        txtPkt.text = "Punkty: " + pktskrytp.PobierzIloscPkt();
    }

    void PrzypiszElementyDoZad()
    {
        txtTrescZad.text = zadaniaAktualnejLekcji[numerZad].PobierzTrescZad().Replace("__",odpUzytkownika);
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
        odpUzytkownika = "__";
        UkryjWszystkiePrzyciskiOdp();
        SprawdzIleJestOdpWZad();
        OdkryjPrzyciskiOdp();
        PrzypiszWartosciDoPrzyciskow();
        PrzypiszElementyDoZad();
        WyswietlNrZad();
        PrzypiszZdjDoZadania();
    }

    void PrzypiszZdjDoZadania()
    {
        if(zadaniaAktualnejLekcji[numerZad].PobierzZdjDoZad() != null)
        {
            imgZdjecieDoZad.sprite = zadaniaAktualnejLekcji[numerZad].PobierzZdjDoZad();
        }
    }

    void SprawdzIleJestOdpWZad()
    {
        ileJestOdpWZadaniu = 0;
        for (int i = 0; i < 3; i++)
        {
            if(zadaniaAktualnejLekcji[numerZad].PobierzZlaOdp(i + 1) != "")
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
                listaOdp.Add(zadaniaAktualnejLekcji[numerZad].PobierzPrawidlowaOdp());
            }
            else
            {
                listaOdp.Add(zadaniaAktualnejLekcji[numerZad].PobierzZlaOdp(i));
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
        PrzypiszElementyDoZad();
    }

    public void SprawdzOdp()
    {
        if(odpUzytkownika == zadaniaAktualnejLekcji[numerZad].PobierzPrawidlowaOdp())
        {
            print("Odp poprawna");
            if(numerLekcji == gm.PobierzIloscUkonczonychLekcji())
            {
                pktskrytp.DodajPkt(1);
            }
            sm.OdtworzDzwiek(0);
            WyswietlIloscPkt();
            PrzelaczNastepneZad();


        }
        else
        {
            print("Odp niepoprawna");
        }
    }

    void PrzelaczNastepneZad()
    {
        if(numerZad < zadaniaAktualnejLekcji.Length -1)
        {
            numerZad ++;
            gm.ZwiekszNrZad();
            TworzNoweZad();
        }
        else
        {
            ZakonczLekcje();
        }
    }

    void ZakonczLekcje()
    {
        AktywujPanelUkonczeniaLekcji(true);
        if(numerLekcji == gm.PobierzIloscUkonczonychLekcji())
        {
            gm.DodajUkonczonaLekcje();
            gm.ResteujNrZadania();
        }
        sm.OdtworzDzwiek(1);

    }

    public void ZamknijPanelUkonczeniaLekcji()
    {
        AktywujPanelUkonczeniaLekcji(false);
        PrzejdDoMenu();
    }

    void AktywujPanelUkonczeniaLekcji(bool odkryj)
    {
        panelUkonczeniaLekcji.SetActive(odkryj);
        
    }
    void WyswietlNrZad()
    {
        txtNrZad.text = "Zadanie: " + numerZad + 1;
    }

    public void PrzejdDoMenu()
    {
        gm.PrzelaczScene(0);
    }

    void Update()
    {
        
    }
}
