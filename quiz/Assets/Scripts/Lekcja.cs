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
    [SerializeField] Text txtPodsumowanieLekcji;
    [SerializeField] Text txtPodpowiedz;
    [SerializeField] Button[] przyciskiOdp;
    [SerializeField] Zadanie[] zadaniaLekcja0;
    [SerializeField] Zadanie[] zadaniaLekcja1;
    [SerializeField] Zadanie[] zadaniaLekcja2;
    [SerializeField] Zadanie[] zadaniaLekcja3;
    [SerializeField] Zadanie[] zadaniaLekcja4;
    [SerializeField] Image imgZdjecieDoZad;
    [SerializeField] Slider sliderPostepu;
    [SerializeField] GameObject panelZPrzyciskami;
    [SerializeField] GameObject panelZPolemOdp;
    [SerializeField] GameObject panelPodpowiedzi;

    Zadanie[] zadaniaAktualnejLekcji;
    Punkty pktskrytp;
    GameManger gm;
    SoundManager sm;
    int numerZad;
    int numerLekcji = 0;
    int ileJestOdpWZadaniu;
    string odpUzytkownika;
    bool czyTojest1Odp;
    bool czyJestesmyWTrybieWpisywaniaOdp;
    void Start()
    {
        OdkryjPanelZOdp(false);
        OdkryjPanelZPrzyciskami(false);
        czyTojest1Odp = true;
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

        sliderPostepu.maxValue = zadaniaAktualnejLekcji.Length;
        sliderPostepu.value = numerZad;

        TworzNoweZad();
        WyswietlNrZad();
        WyswietlIloscPkt();
        //print(numerLekcji);
        //print(gm.PobierzIloscUkonczonychLekcji());
    }

    void OdkryjPanelZPrzyciskami(bool odkryj)
    {
        panelZPrzyciskami.SetActive(odkryj);
    }

    void OdkryjPanelZOdp(bool odkryj)
    {
        panelZPolemOdp.SetActive(odkryj);
    }

    public void OdkryjPanelPodpowiedzi(bool odkryj)
    {
        panelPodpowiedzi.SetActive(odkryj);
        if(odkryj == true)
        {
            czyTojest1Odp = false;
            txtPodpowiedz.text = zadaniaAktualnejLekcji[numerZad].PobierzPrawidlowaOdp();
        }
        else
        {
            txtPodpowiedz.text = "";
        }
    }

    void DodajPodsumowanie()
    {
        string podsumowanie = "Uzyskano " + pktskrytp.PobierzIloscPktAktualnejLekcji() + " z " + zadaniaAktualnejLekcji.Length + " możliwych punktów";
        txtPodsumowanieLekcji.text = podsumowanie;
    }

    void UstawLekcje(int nrLekcji)
    {
        numerLekcji = nrLekcji;
        txtNrLekcji.text = "Lekcja: " + nrLekcji;
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
            case 3: 
                zadaniaAktualnejLekcji = zadaniaLekcja3;
                break;
            case 4: 
                zadaniaAktualnejLekcji = zadaniaLekcja4;
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
        //print("ilosc odpowiedzi w zadaniu: " + ileJestOdpWZadaniu);
    }
    void UkryjWszystkiePrzyciskiOdp()
    {
        for (int i = 0; i < przyciskiOdp.Length; i++)
        {
            przyciskiOdp[i].gameObject.SetActive(false);
        }
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
        odpUzytkownika = "_";
        UkryjWszystkiePrzyciskiOdp();
        SprawdzIleJestOdpWZad();
        if(ileJestOdpWZadaniu == 1)
        {
            OdkryjPanelZOdp(true);
            OdkryjPanelZPrzyciskami(false);
            czyJestesmyWTrybieWpisywaniaOdp = true;
        }
        else
        {
            czyJestesmyWTrybieWpisywaniaOdp = false;
            OdkryjPanelZPrzyciskami(true);
            OdkryjPanelZOdp(false);
            OdkryjPrzyciskiOdp();
            PrzypiszWartosciDoPrzyciskow();
        }
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
    void WyswietlNrZad()
    {
        txtNrZad.text = "Zadanie: " + (numerZad + 1);
    }

    public void PrzypiszElementyDoZad()
    {
        if(czyJestesmyWTrybieWpisywaniaOdp)
        {
            txtTrescZad.text = zadaniaAktualnejLekcji[numerZad].PobierzTrescZad().Replace("__", panelZPolemOdp.GetComponentInChildren<InputField>().text);
        }
        else
        {
            txtTrescZad.text = zadaniaAktualnejLekcji[numerZad].PobierzTrescZad().Replace("__",odpUzytkownika);
        }
    }
    public void PobierzOdpUzytkownika(string odp) 
    {
        odpUzytkownika = odp;
        PrzypiszElementyDoZad();
    }

    public void SprawdzOdp()
    {
        if(odpUzytkownika == zadaniaAktualnejLekcji[numerZad].PobierzPrawidlowaOdp() || panelZPolemOdp.GetComponentInChildren<InputField>().text.ToLower().Trim() == zadaniaAktualnejLekcji[numerZad].PobierzPrawidlowaOdp())
        {
            //print("Odp poprawna");
            if(numerLekcji == gm.PobierzIloscUkonczonychLekcji())
            {
                if(czyTojest1Odp)
                {
                    pktskrytp.DodajPkt(1);
                }
            }
            sm.OdtworzDzwiek(0);
            WyswietlIloscPkt();
            PrzelaczNastepneZad();
            sliderPostepu.value = numerZad;
        }
        else
        {
            //print("Odp niepoprawna");
            czyTojest1Odp = false;
        }
        panelZPolemOdp.GetComponentInChildren<InputField>().text = "";
    }
    void PrzelaczNastepneZad()
    {
        czyTojest1Odp = true;
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
        GetComponent<AdsManager>().WlaczReklameCor();
        AktywujPanelUkonczeniaLekcji(true);
        if(numerLekcji == gm.PobierzIloscUkonczonychLekcji())
        {
            gm.DodajUkonczonaLekcje();
            gm.ResteujNrZadania();
        }
        sm.OdtworzDzwiek(1);
    }

    void AktywujPanelUkonczeniaLekcji(bool odkryj)
    {
        DodajPodsumowanie();
        panelUkonczeniaLekcji.SetActive(odkryj);
        pktskrytp.ResetujIloscPktwAktualnejLekcji();
    }

    public void ZamknijPanelUkonczeniaLekcji()
    {
        AktywujPanelUkonczeniaLekcji(false);
        PrzejdDoMenu();
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
    public void PrzejdDoMenu()
    {
        gm.PrzelaczScene(0);
    }
}
