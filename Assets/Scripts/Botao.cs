using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Botao : MonoBehaviour {
    
        public GameObject preenchido;
        public GameObject preencher;
        public  GameObject atual;
        public int lin;
        public int col;

    // Use this for initialization
    void Start () {
        bool Preen;
        Preen = atual.GetComponent<Jogo>().Preencher(lin,col);
        if (Preen)
        {
            preenchido.SetActive(true);
            preencher.SetActive(false);
            int k = atual.GetComponent<Jogo>().Tab2[lin, col];
            string num = k.ToString();
            preenchido.GetComponentInChildren<TextMeshProUGUI>().text = num;
        } else
        {
            preenchido.SetActive(false);
            preencher.SetActive(true);
        }

    }

}
