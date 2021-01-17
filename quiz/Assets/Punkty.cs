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
            iloscPkt = PlayerPrefs.GetInt("SavePunkty");
        }
    }
    
    int iloscPkt;
  
    public void DodajPkt(int punkty)
    {
        iloscPkt = PlayerPrefs.GetInt("SavePunkty");
        iloscPkt += punkty;
        PlayerPrefs.SetInt("SavePunkty", iloscPkt);
    }

    public int PobierzIloscPkt()
    {
        return PlayerPrefs.GetInt("SavePunkty");
    }
}
