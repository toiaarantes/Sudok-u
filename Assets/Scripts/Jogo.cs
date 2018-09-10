using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogo : MonoBehaviour
{
    public int[,,] Tab2 = new int[9, 9, 2];
    public System.Random rnd = new System.Random();
    public System.Random num = new System.Random();
    public GameObject dificuldades;
    public GameObject tabuleiro;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Tab2[i, j, 0] = num.Next(1, 10);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Dificuldade(int d)
    {
        int fac;
        bool playdif = true;
        int RandomNumber;
        System.Random Rnbr = new System.Random();

        if (d == 0)
        {
            Debug.Log("facil");
            fac = 0;
            RandomNumber = Rnbr.Next(55, 75);
            while (playdif)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Tab2[i, j, 1] = rnd.Next(0, 2);
                        Debug.Log(fac);
                        if (Tab2[i, j, 1] == 1)
                            fac++;
                        if (fac>RandomNumber)
                        {
                            i = 9;
                            j = 9;
                            playdif = false;
                        }
                    }
                }
            }
        }
        else
        {
            if (d == 1)
            {
                Debug.Log("medio");
                fac = 0;
                RandomNumber = Rnbr.Next(35, 55);
                while (fac < 40)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            Tab2[i, j, 1] = rnd.Next(0, 2);
                            Debug.Log(fac);

                            if (Tab2[i, j, 1] == 1)
                                fac++;
                            if (fac > RandomNumber)
                            {
                                i = 9;
                                j = 9;
                                playdif = false;
                            }
                        }
                    }
                }
            }
            else
            {

                if (d == 2)
                {
                    fac = 0;
                    RandomNumber = Rnbr.Next(20, 35);
                    Debug.Log("Dificil");
                    while (playdif)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                Debug.Log(fac);
                                Tab2[i, j, 1] = rnd.Next(0, 2);
                                if (Tab2[i, j, 1] == 1)
                                {
                                    fac++;
                                    if (fac>RandomNumber)
                                    {
                                        playdif = false;
                                        j = 9;
                                        i = 9;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        dificuldades.SetActive(false);
        tabuleiro.SetActive(true);

    }

    public bool Preencher(int i, int j)
    {
        if (Tab2[i, j, 1] == 1)
        {
            return true;
        }
        else
            return false;
    }

    /* public int Valor(int i, int j)
      {
          return Tab[i, j, 0];
      } */
}
