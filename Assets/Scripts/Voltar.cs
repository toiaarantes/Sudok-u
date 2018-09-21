using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class Voltar : MonoBehaviour
{

    private bool selected = false;
    private GameObject selectedbutton;
    public GameObject atual;
    private GameObject vater;


    public void VoltarMenu()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void Preencher(string numero)
    {
        if (selected == true)
        {
            int n;
            selectedbutton.GetComponentInChildren<TextMeshProUGUI>().text = numero;
            if (numero == "")
                n = 0;
            else
            { n = int.Parse(numero); }
            Preencher(n);

        }

    }

    public void Selected(GameObject botao)
    {
        if (botao == selectedbutton)
            selected = !selected;
        else
        {
            selectedbutton = botao;
            selected = true;
        }
        Debug.Log("Funcao");
    }

    public void ReturnPai(GameObject pai)
    {
        vater=pai;
    }

    private void Preencher(int num)
    {
        int i = vater.GetComponent<Botao>().lin;
        int j = vater.GetComponent<Botao>().col;
        atual.GetComponent<Jogo>().Tab2[i, j] = num;
    }


    private void Testar ()
    {
        if (selected == true)
        { if (selectedbutton.GetComponentInChildren<TextMeshProUGUI>().text == "x")
            {

            }


                }
    }
        
}