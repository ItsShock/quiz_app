using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrzyciskDoZmianyLekcji : MonoBehaviour
{
    [SerializeField] Image img;
    int numerLekcji;
    int iloscUkonczonychLekcji;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<GameManger>().PobierzNumerLekcjiZPrzycisku(System.Convert.ToInt32( GetComponentInChildren<Text>().text)));
        numerLekcji = System.Convert.ToInt32( GetComponentInChildren<Text>().text);
        iloscUkonczonychLekcji = FindObjectOfType<GameManger>().PobierzIloscUkonczonychLekcji();

        if(numerLekcji - 1 > iloscUkonczonychLekcji)
        {
            GetComponent<Button>().interactable = false;
            img.gameObject.SetActive(true);
        }
        else
        {
            GetComponent<Button>().interactable = true;
            img.gameObject.SetActive(false);
        }
    }
}
