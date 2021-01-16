using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zadanie", menuName = "Utwórz nowe zadanie")]
public class Zadanie : ScriptableObject
{
    [SerializeField] int typZad;
    [TextArea(10,100)]
    [SerializeField] string TrescZad;
    [SerializeField] string PrawidlowaOdp;
    [SerializeField] string ZlaOdp1;
    [SerializeField] string ZlaOdp2;
    [SerializeField] string ZlaOdp3;

    public string PobierzTrescZad()
    {
        return TrescZad;
    }

    public string PobierzPrawidlowaOdp()
    {
        return PrawidlowaOdp;
    }

     public string PobierzZlaOdp(int numerOdpowiedzi)
    {
        
        if(numerOdpowiedzi == 1)
        {
            return ZlaOdp1;
        }
        else if(numerOdpowiedzi == 2)
        {
            return ZlaOdp2;
        }
        else if(numerOdpowiedzi == 3)
        {
            return ZlaOdp3;
        }
        else
        {
            return "bląd";
        }
        
    }
}
