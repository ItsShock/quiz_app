using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punkty : MonoBehaviour
{
    void Awake()
    {
        if(!PlayerPrefs.HasKey("SavePunkty"))
        {
            PlayerPrefs.SetInt("SavePunkty",0);
            iloscPkt = 0;
        }
        else
        {
            iloscPkt = PlayerPrefs.GetInt("SavePunktywAktualnejLekcji");
        }

        if(!PlayerPrefs.HasKey("SavePunktywAktualnejLekcji"))
        {
            PlayerPrefs.SetInt("SavePunktywAktualnejLekcji",0);
            iloscPktAktualnejLekcji = 0;
        }
        else
        {
            iloscPktAktualnejLekcji = PlayerPrefs.GetInt("SavePunktywAktualnejLekcji");
        }
    }
    int iloscPkt;
    int iloscPktAktualnejLekcji;


  
    public void DodajPkt(int punkty)
    {
        iloscPkt = PlayerPrefs.GetInt("SavePunkty");
        iloscPkt += punkty;
        PlayerPrefs.SetInt("SavePunkty", iloscPkt);

        iloscPktAktualnejLekcji = PlayerPrefs.GetInt("SavePunktywAktualnejLekcji");
        iloscPktAktualnejLekcji += punkty;
        PlayerPrefs.SetInt("SavePunktywAktualnejLekcji",iloscPktAktualnejLekcji);

    }

    public int PobierzIloscPkt()
    {
        return PlayerPrefs.GetInt("SavePunkty");
    }

    public int PobierzIloscPktAktualnejLekcji()
    {
        return PlayerPrefs.GetInt("SavePunktywAktualnejLekcji");
    }

    public void ResetujIloscPkt()
    {
        PlayerPrefs.SetInt("SavePunkty", 0);
    }

    public void ResetujIloscPktwAktualnejLekcji()
    {
        PlayerPrefs.SetInt("SavePunktywAktualnejLekcji", 0);
    }
}
