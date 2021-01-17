using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrzyciskDoZmianyLekcji : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<GameManger>().PobierzNumerLekcjiZPrzycisku(System.Convert.ToInt32( GetComponentInChildren<Text>().text)));
    }
}
