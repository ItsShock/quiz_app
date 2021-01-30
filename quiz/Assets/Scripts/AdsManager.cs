using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    
    
    IEnumerator WlaczReklame()
    {
        Advertisement.Initialize("3978051", false);
        while (!Advertisement.IsReady())
        {
            yield return null;
        }
        Advertisement.Show();
    }

    public void WlaczReklameCor()
    {
        StartCoroutine(WlaczReklame());
    }
}
