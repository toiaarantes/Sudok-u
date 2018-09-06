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


    public void VoltarMenu()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void Preencher(string numero)
    {
        if (selected == true)
        {
            selectedbutton.GetComponentInChildren<TextMeshProUGUI>().text = numero;

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

}