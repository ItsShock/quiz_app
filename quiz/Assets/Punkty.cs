using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punkty : MonoBehaviour
{
    [SerializeField] Text txtPkt;
    int iloscPkt;
    void Start()
    {
        iloscPkt = 0;
        WyswietlIloscPkt();
    }

    
    void Update()
    {
        
    }

    public void DodajPkt(int punkty)
    {
        iloscPkt += punkty;
        WyswietlIloscPkt();
    }

    void WyswietlIloscPkt()
    {
        txtPkt.text = "Punkty: " + iloscPkt;
    }
}
