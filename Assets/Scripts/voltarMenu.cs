using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class voltarMenu : MonoBehaviour {

    private bool selected = false;
    private GameObject selectedbutton;
    public int[,,] Tab = new int[9, 9, 2];
    GameObject preenchido;
    GameObject preencher;
    int linha;
    int coluna;

    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Tab[i, j, 0] = 0;
                Tab[i, j, 1] = 0;
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                int rand = Random.Range(1, 9);
                Tab[i, j, 0] = rand;
            }
        }
    }


    public void Preencher2()
    {
        int rand = Random.Range(50, 60);

        while (rand != 0)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int r2 = Random.Range(0, 9);
                    if (r2 % 2 == 0)
                    {
                        Tab[i, j, 1] = 1;
                        rand--;
                    }

                }
            }
        }

    }

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




    public void Pchido(GameObject bt1)
    {
        preenchido = bt1;
    }

    

    public void Linha (int i)
        {
            linha= i;
        }

    public void Coluna (int j)
    {
        coluna = j;
    }
    public void Pcher(GameObject bt2)
    {
        if (bt2 != preencher)
        {
            preencher = bt2;
            funPreencher();
        }
    }
    public void funPreencher()
    {
        string num = Tab[linha, coluna, 0].ToString();
        if (Tab[linha, coluna, 1] == 1)
        {
            preenchido.SetActive(true);
            preencher.SetActive(false);
            preenchido.GetComponentInChildren<TextMeshProUGUI>().text = num;
        }
        else
        {
            preenchido.SetActive(true);
            preencher.SetActive(false);
        }
    }
}
