using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrzyciskOdp : MonoBehaviour
{
    Text txtButton;
    void Start()
    {
        txtButton = GetComponentInChildren<Text>();
        GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<Lekcja>().PobierzOdpUzytkownika(txtButton.text));
    }

    
}
