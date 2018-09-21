using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogo : MonoBehaviour
{
    //public int[,] Tab2 = new int[9, 9];
    public int[,] Tab2 = new int[,] {{6,1,7,4,9,5,3,8,2},
                                     { 4,2,5,6,3,8,7,9,1},
                                     {3,8,9,2,1,7,5,4,6},
                                     {5,6,2,7,8,3,4,1,9},
                                     {9,4,1,5,6,2,8,7,3},
                                     {7,3,8,1,4,9,6,2,5},
                                     {8,5,4,3,2,1,9,6,7},
                                       {2,7,6,9,5,4,1,3,8},
                                         {1,9,3,8,7,6,2,5,0}};
    private int[,] TabAux = new int[9, 9];
    public System.Random rnd = new System.Random();
    public System.Random num = new System.Random();
    public GameObject dificuldades;
    public GameObject tabuleiro;
    public GameObject ganhou;
    private bool ativo = false;

    /*    private struct Possibilidades
        {
            private int[,] Mat;
            private List<int>[]
        }*/

    // Use this for initialization
    void Start()
    {
       // int cont = 0;
        //Sortear();
       /* while (!Checar() && cont < 100)
        {
            Organizar();
            Inverter();
            cont++;
        }
        cont = 0;
        while (!Checar() && cont < 100)
        {
            Solver();
        }
        if (!Checar())
        {
            Debug.Log("Tabuleiro falhou");
            RemoverRepetidos();
        }
        else
            Debug.Log("Tabuleiro funcionou");*/

    }
    // Update is called once per frame
    void Update()
    {
        if (Checar() && ativo)
        {
            tabuleiro.SetActive(false);
            ganhou.SetActive(true);
        }

    }

    public void Recomecar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Dificuldade(int d)
    {
        /*int fac;
        bool playdif = true;
        int RandomNumber;
        System.Random Rnbr = new System.Random();

        if (d == 0)
        {
            Debug.Log("facil");
            fac = 0;
            RandomNumber = Rnbr.Next(20, 25);
            while (playdif)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        int ale = rnd.Next(0, 10);
                        if (ale%4 == 0)
                            Tab2[i, j] = 0;
                        Debug.Log(fac);
                        if (Tab2[i, j] == 0)
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
            if (d == 1)
            {
                Debug.Log("medio");
                fac = 0;
                RandomNumber = Rnbr.Next(25, 45);
                while (playdif)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            int ale = rnd.Next(0, 2);
                            Debug.Log(fac);
                            if (ale == 0)
                                Tab2[i, j] = 0;
                            if (Tab2[i, j] == 0)
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
                    RandomNumber = Rnbr.Next(45, 60);
                    Debug.Log("Dificil");
                    while (playdif)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                Debug.Log(fac);
                                int ale = rnd.Next(0, 2);
                                if (ale == 0)
                                    Tab2[i, j] = 0;
                                if (Tab2[i, j] == 0)
                                {
                                    fac++;
                                    if (fac > RandomNumber)
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
        }*/
        dificuldades.SetActive(false);
        tabuleiro.SetActive(true);
        ativo = true;

    }

    public bool Preencher(int i, int j)
    {
        if (Tab2[i, j] == 0)
        {
            return false;
        }
        else
            return true;
    }

    private void Sortear()
    {
        int[] In = { 0, 0, 3, 3, 0, 6, 6, 3, 6, 0 };
        int[] Fn = { 3, 3, 6, 6, 3, 9, 9, 6, 9, 3 };
        List<int>[] valuesCopy = new List<int>[9];
        int[] valueIndex = new int[9];
        for (int k = 0; k < 9; k++)
        {
            valuesCopy[k] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        for (int k = 0; k < 9; k++)
        {
            for (int i = In[k]; i < Fn[k]; i++)
            {
                for (int j = In[k + 1]; j < Fn[k + 1]; j++)
                {
                    valueIndex[k] = Random.Range(0, valuesCopy[k].Count - 1);
                    Tab2[i, j] = valuesCopy[k][valueIndex[k]];
                    valuesCopy[k].Remove(valuesCopy[k][valueIndex[k]]);
                }
            }
        }
    }

    public void Organizar()
    {
        for (int b = 0; b < 9; b++)
        {
            for (int k = b + 1; k < 9; k++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (Tab2[b, j] == Tab2[b, k])
                    {
                        if (!BASlinha(b, k))
                            if (!PASlinha(b, j, 0))
                                if (!BASlinha(b, k))
                                    PASlinha(b, j, 0);
                    }
                }
            }
            for (int k = b + 1; k < 9; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    if (Tab2[i, b] == Tab2[k, b])
                    {
                        if (!BAScoluna(k, b))
                            if (!PAScoluna(i, b, 0))
                                if (!BAScoluna(k, b))
                                    PAScoluna(i, b, 0);


                    }
                }
            }
        }
        /* for (int b = 0; b < 9; b++)
         {
             for (int k = b + 1; k < 9; k++)
             {
                 for (int j = 0; j < k; j++)
                 {
                     if (Tab2[b, j] == Tab2[b, k])
                     {
                         if (!BASlinha(b, k))
                             PASlinha(b, k, 0);
                     }
                 }
             }
             for (int k = b + 1; k < 9; k++)
             {
                 for (int i = 0; i < k; i++)
                 {
                     if (Tab2[i, b] == Tab2[k, b])
                     {
                         if (!BAScoluna(k, b))
                             PAScoluna(k, b, 0);


                     }
                 }
             }*/
        if (!Checar())
            Debug.Log("Tabuleiro falhou");
        else
            Debug.Log("Tabuleiro funcionou");
    }
    //Inverter();

    /* for (int b = 0; b < 9; b++)
            {
                for (int k = b + 1; k < 9; k++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (Tab2[b, j] == Tab2[b, k])
                        {
                            PASlinha(b, j,0);
                        }
                    }
                }
                for (int k = b + 1; k < 9; k++)
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (Tab2[i, b] == Tab2[k, b])
                        {
                            PAScoluna(i, b,0);
                        }
                    }
                }
            }*/



    public void Teste1()
    {
        for (int b = 0; b < 9; b++)
        {
            for (int k = b + 1; k < 9; k++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (Tab2[b, j] == Tab2[b, k])
                    {
                        BASlinha(b, k);

                    }
                }
            }
            for (int k = b + 1; k < 9; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    if (Tab2[i, b] == Tab2[k, b])
                    {
                        BAScoluna(k, b);

                    }
                }
            }
        }
    }
    public void Teste2()
    {
        for (int b = 0; b < 9; b++)
        {
            for (int k = b + 1; k < 9; k++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (Tab2[b, j] == Tab2[b, k])
                    {

                        PASlinha(b, j, 0);
                    }
                }
            }
            for (int k = b + 1; k < 9; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    if (Tab2[i, b] == Tab2[k, b])
                    {

                        PAScoluna(i, b, 0);
                    }
                }
            }
        }
    }
    public void Teste3()
    {
        for (int b = 0; b < 9; b++)
        {
            for (int k = b + 1; k < 9; k++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (Tab2[b, j] == Tab2[b, k])
                    {

                        PASlinha(b, k, 0);
                    }
                }
            }
            for (int k = b + 1; k < 9; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    if (Tab2[i, b] == Tab2[k, b])
                    {

                        PAScoluna(k, b, 0);
                    }
                }
            }
        }
    }
    private void TrocaLado1(int i, int j)
    {
        TabAux[i, j] = Tab2[i + 1, j];
        Tab2[i + 1, j] = Tab2[i, j];
        Tab2[i, j] = TabAux[i, j];
    }
    private void TrocaLado2(int i, int j)
    {
        TabAux[i, j] = Tab2[i + 2, j];
        Tab2[i + 2, j] = Tab2[i, j];
        Tab2[i, j] = TabAux[i, j];
    }
    private bool BASlinha(int i, int j)
    {
        int[] lin = new int[2];
        int[] col = new int[2];
        lin[0] = (i / 3) * 3;
        lin[1] = ((i / 3) + 1) * 3;
        col[0] = (j / 3) * 3;
        col[1] = ((j / 3) + 1) * 3;

        if (lin[1] - i == 1)
        {
            return false;
        }
        if (lin[1] - i == 2)
        {

            for (int a = col[0]; a < col[1]; a++)
            {
                bool Serve = true;

                for (int k = 0; k < j; k++)
                {
                    if (Tab2[i + 1, a] == Tab2[i, k])
                    {
                        Serve = false;
                    }
                }
                if (Serve)
                {
                    TabAux[i, j] = Tab2[i + 1, a];
                    Tab2[i + 1, a] = Tab2[i, j];
                    Tab2[i, j] = TabAux[i, j];
                    return true;
                }
            }
            return false;
        }
        if (lin[1] - i == 3)
        {

            for (int a = col[0]; a < col[1]; a++)
            {
                bool Serve = true;

                for (int k = 0; k < j; k++)
                {
                    if (Tab2[i + 1, a] == Tab2[i, k])
                    {
                        Serve = false;
                    }

                }
                if (Serve)
                {
                    TabAux[i, j] = Tab2[i + 1, a];
                    Tab2[i + 1, a] = Tab2[i, j];
                    Tab2[i, j] = TabAux[i, j];
                    return true;
                }
            }
            for (int a = col[0]; a < col[1]; a++)
            {
                bool Serve = true;

                for (int k = 0; k < j; k++)
                {
                    if (Tab2[i + 2, a] == Tab2[i, k])
                    {
                        Serve = false;
                    }
                }
                if (Serve)
                {
                    TabAux[i, j] = Tab2[i + 2, a];
                    Tab2[i + 2, a] = Tab2[i, j];
                    Tab2[i, j] = TabAux[i, j];


                    return true;
                }
            }
            return false;
        }
        return false;
    }
    private bool BAScoluna(int i, int j)
    {
        int[] lin = new int[2];
        int[] col = new int[2];
        lin[0] = (i / 3) * 3;
        lin[1] = ((i / 3) + 1) * 3;
        col[0] = (j / 3) * 3;
        col[1] = ((j / 3) + 1) * 3;
        if (j == i)
        {
            bool Serve = true;

            for (int k = 0; k < i; k++)
            {
                if (Tab2[i, j + 1] == Tab2[k, j])
                {
                    Serve = false;
                }
            }
            if (Serve)
            {
                TabAux[i, j] = Tab2[i, j + 1];
                Tab2[i, j + 1] = Tab2[i, j];
                Tab2[i, j] = TabAux[i, j];
                return true;
            }
            Serve = true;

            for (int k = 0; k < i; k++)
            {
                if (Tab2[i, j + 2] == Tab2[k, j])
                {
                    Serve = false;
                }
            }
            if (Serve)
            {
                TabAux[i, j] = Tab2[i, j + 2];
                Tab2[i, j + 2] = Tab2[i, j];
                Tab2[i, j] = TabAux[i, j];
                return true;
            }
            else
            {
                return false;
            }
        }
        if (j > lin[0])
            lin[0] = j + 1;


        if (col[1] - j == 1)
        {
            return false;
        }
        if (col[1] - j == 2)
        {

            for (int a = lin[0]; a < lin[1]; a++)
            {
                bool Serve = true;

                for (int k = 0; k < i; k++)
                {
                    if (Tab2[a, j + 1] == Tab2[k, j])
                    {
                        Serve = false;
                    }
                }
                if (Serve)
                {
                    TabAux[i, j] = Tab2[a, j + 1];
                    Tab2[a, j + 1] = Tab2[i, j];
                    Tab2[i, j] = TabAux[i, j];
                    return true;
                }
            }
            return false;
        }
        if (col[1] - j == 3)
        {

            for (int a = lin[0]; a < lin[1]; a++)
            {
                bool Serve = true;

                for (int k = 0; k <= i; k++)
                {
                    if (Tab2[a, j + 1] == Tab2[k, j])
                    {
                        Serve = false;
                    }
                }
                if (Serve)
                {
                    TabAux[i, j] = Tab2[a, j + 1];
                    Tab2[a, j + 1] = Tab2[i, j];
                    Tab2[i, j] = TabAux[i, j];
                    return true;
                }
            }
            for (int a = lin[0]; a < lin[1]; a++)
            {
                bool Serve = true;

                for (int k = 0; k <= i; k++)
                {
                    if (Tab2[a, j + 2] == Tab2[k, j])
                    {
                        Serve = false;
                    }
                }
                if (Serve)
                {
                    TabAux[i, j] = Tab2[a, j + 2];
                    Tab2[a, j + 2] = Tab2[i, j];
                    Tab2[i, j] = TabAux[i, j];
                    return true;
                }
            }
            return false;
        }
        return false;
    }
    private bool PASlinha(int i, int j, int a)
    {
        int lin;
        lin = (i / 3) * 3;
        if (i == lin + 2)
        {
            return false;
        }
        if (a < 9)
        {
            if (i < lin + 2)
            {
                TrocaLado1(i, j);

                for (int k = 0; k < 9; k++)
                {
                    if (Tab2[k, j] == Tab2[i, j])
                    {
                        a++;
                        PASlinha(k, j, a);

                    }
                }
            }
            /*if (i ==lin + 2)
            {
                TrocaLado1(i-1, j);

                for (int k = 0; k < 9; k++)
                {
                    if (Tab2[k, j] == Tab2[i, j])
                    {
                        a++;
                        PASlinha(k, j, a);

                    }
                }
            }*/
        }
        if (a > 9)
        {
            if (a < 18)
            {
                if (i == lin)
                {
                    TrocaLado2(i, j);

                    for (int k = 0; k < 9; k++)
                    {
                        if (Tab2[k, j] == Tab2[i, j])
                        {
                            a++;
                            PASlinha(k, j, a);

                        }
                    }
                }

                /* if (i == lin + 2)
                 {
                     TrocaLado2(i - 2, j);

                     for (int k = 0; k < 9; k++)
                     {
                         if (Tab2[k, j] == Tab2[i, j])
                         {
                             a++;
                             PASlinha(k, j, a);

                         }
                     }
                 }*/
            }
        }
        if (a > 9)
        {
            if (i != lin)
                return false;
            else
            {
                if (a >= 18)
                    return false;
                else
                    return true;
            }
        }
        else
            return true;
    }

    private bool PAScoluna(int i, int j, int a)
    {
        int col;
        col = (j / 3) * 3;
        if (j == col + 2)
        {
            return false;
        }
        if (a < 9)
        {
            if (j < col + 2)
            {
                TrocaBaixo1(i, j);

                for (int k = 0; k < 9; k++)
                {
                    if (Tab2[i, k] == Tab2[i, j])
                    {
                        a++;
                        PAScoluna(i, k, a);

                    }
                }
            }
            /* if (j == col + 2)
             {
                 TrocaBaixo1(i, j-1);

                 for (int k = 0; k < 9; k++)
                 {
                     if (Tab2[i,k] == Tab2[i, j])
                     {
                         a++;
                         PAScoluna(i, k, a);

                     }
                 }
             }*/
        }
        if (a > 9)
        {
            if (a < 18)
            {
                if (j == col)
                {
                    TrocaBaixo2(i, j);

                    for (int k = 0; k < 9; k++)
                    {
                        if (Tab2[i, k] == Tab2[i, j])
                        {
                            a++;
                            PAScoluna(i, k, a);

                        }
                    }
                }
                /* if (j == col + 2)
                 {
                     TrocaBaixo2(i, j-2);

                     for (int k = 0; k < 9; k++)
                     {
                         if (Tab2[i,k] == Tab2[i, j])
                         {
                             a++;
                             PAScoluna(i, k, a);

                         }
                     }
                 }*/
            }
        }

        if (a > 9)
        {
            if (j != col)
                return false;
            else
            {
                if (a >= 18)
                    return false;
                else
                    return true;
            }
        }
        else
            return true;

    }
    private void TrocaBaixo1(int i, int j)
    {
        TabAux[i, j] = Tab2[i, j + 1];
        Tab2[i, j + 1] = Tab2[i, j];
        Tab2[i, j] = TabAux[i, j];
    }
    private void TrocaBaixo2(int i, int j)
    {
        TabAux[i, j] = Tab2[i, j + 2];
        Tab2[i, j + 2] = Tab2[i, j];
        Tab2[i, j] = TabAux[i, j];
    }
    private bool Checar()
    {
        //checar as linhas
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int k = 0; k < j; k++)
                {
                    if (Tab2[i, j] == Tab2[i, k])
                        return false;
                }
            }
        }
        //checar as colunas
        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    if (Tab2[i, j] == Tab2[k, j])
                        return false;
                }
            }
        }
        //checar os quadrados
        int[] In = { 0, 0, 3, 3, 0, 6, 6, 3, 6, 0 };
        int[] Fn = { 3, 3, 6, 6, 3, 9, 9, 6, 9, 3 };

        for (int k = 0; k < 9; k++)
        {
            for (int i = In[k]; i < Fn[k]; i++)
            {
                for (int j = In[k + 1]; j < Fn[k + 1]; j++)
                {
                    for (int a = In[k]; a < Fn[k]; a++)
                    {
                        if (Tab2[i, j] == Tab2[a, j] && a != i)
                            return false;
                    }
                    for (int b = In[k + 1]; b < Fn[k + 1]; b++)
                    {
                        if (Tab2[i, j] == Tab2[i, b] && b != j)
                            return false;
                    }
                }
            }
        }

        //checar presenca de zeros
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
                if (Tab2[i, j] == 0)
                    return false;
        return true;
    }

    public void Inverter()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                TabAux[8 - i, 8 - j] = Tab2[i, j];

            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Tab2[i, j] = TabAux[i, j];

            }
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = i; j < 9; j++)
            {
                TabAux[i, j] = Tab2[j, i];
                Tab2[j, i] = Tab2[i, j];
                Tab2[i, j] = TabAux[i, j];
            }
        }
    }

    private void Sortear036()
    {
        int[] In = { 0, 0, 3, 3, 0, 6, 6, 3, 6, 0 };
        int[] Fn = { 3, 3, 6, 6, 3, 9, 9, 6, 9, 3 };
        List<int>[] valuesCopy = new List<int>[9];
        int[] valueIndex = new int[9];
        for (int a = 0; a < 9; a++)
        {
            valuesCopy[a] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        int k = 0;
        for (int i = In[k]; i < Fn[k]; i++)
        {
            for (int j = In[k + 1]; j < Fn[k + 1]; j++)
            {
                valueIndex[k] = Random.Range(0, valuesCopy[k].Count - 1);
                Tab2[i, j] = valuesCopy[k][valueIndex[k]];
                valuesCopy[k].Remove(valuesCopy[k][valueIndex[k]]);
            }
        }
        k = 4;
        for (int i = In[k]; i < Fn[k]; i++)
        {
            for (int j = In[k + 1]; j < Fn[k + 1]; j++)
            {
                valueIndex[k] = Random.Range(0, valuesCopy[k].Count - 1);
                Tab2[i, j] = valuesCopy[k][valueIndex[k]];
                valuesCopy[k].Remove(valuesCopy[k][valueIndex[k]]);
            }
        }
        k = 8;
        for (int i = In[k]; i < Fn[k]; i++)
        {
            for (int j = In[k + 1]; j < Fn[k + 1]; j++)
            {
                valueIndex[k] = Random.Range(0, valuesCopy[k].Count - 1);
                Tab2[i, j] = valuesCopy[k][valueIndex[k]];
                valuesCopy[k].Remove(valuesCopy[k][valueIndex[k]]);
            }
        }
    }

    private void RemoverRepetidos()
    {
        /* for (int i = 0; i < 9; i++)
         {
             for (int j = 0; j < 9; j++)
             {
                 for (int k = 0; k < j; k++)
                 {
                     if (Tab2[i, j] == Tab2[i, k])
                     {
                         Tab2[i, j] = 0;
                         Tab2[i, k] = 0;
                     }
                 }
             }
         }

         for (int j = 0; j < 9; j++)
         {
             for (int i = 0; i < 9; i++)
             {
                 for (int k = 0; k < i; k++)
                 {
                     if (Tab2[i, j] == Tab2[k, j])
                     {
                         Tab2[i, j] = 0;
                         Tab2[k, j] = 0;
                     }
                 }
             }
         }*/
        int[] In = { 0, 0, 3, 3, 0, 6, 6, 3, 6, 0 };
        int[] Fn = { 3, 3, 6, 6, 3, 9, 9, 6, 9, 3 };

        for (int k = 0; k < 9; k++)
        {
            for (int i = In[k]; i < Fn[k]; i++)
            {
                for (int j = In[k + 1]; j < Fn[k + 1]; j++)
                {
                    if (k != 0 && k != 5 && k != 2)
                    {
                        Tab2[i, j] = 0;
                    }
                }
            }
        }

    }
    private void Solver()
    {
        List<int>[,] valoresPossiveis = new List<int>[9, 9];

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (Tab2[i, j] == 0)
                    valoresPossiveis[i, j] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                else
                    valoresPossiveis[i, j] = null;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int a = 0; a < 9; a++)
                {
                    if (Tab2[i, j] != 0)
                    {
                        if (Tab2[a, j] == 0)
                        {
                            if (valoresPossiveis[a, j].Contains(Tab2[i, j]))
                            {
                                for (int b = 0; b < valoresPossiveis[a, j].Count; b++)
                                {
                                    if (valoresPossiveis[a, j][b] == Tab2[i, j])
                                        valoresPossiveis[a, j].Remove(valoresPossiveis[a, j][b]);
                                }
                            }
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int a = 0; a < 9; a++)
                {
                    if (Tab2[i, j] != 0)
                    {
                        if (Tab2[i, a] == 0)
                        {
                            if (valoresPossiveis[i, a].Contains(Tab2[i, j]))
                            {
                                for (int b = 0; b < valoresPossiveis[i, a].Count; b++)
                                {
                                    if (valoresPossiveis[i, a][b] == Tab2[i, j])
                                        valoresPossiveis[i, a].Remove(valoresPossiveis[i, a][b]);
                                }
                            }
                        }
                    }
                }
            }
        }

        int[] In = { 0, 3, 0, 6, 3, 6, 0 };
        int[] Fn = { 3, 6, 3, 9, 6, 9, 3 };
        
        for (int k = 0; k < 6; k++)
        {
            for (int i = In[k]; i < Fn[k]; i++)
            {
                for (int j = In[k + 1]; j < Fn[k + 1]; j++)
                {
                    for (int a = In[k]; a < Fn[k]; a++)
                    {
                        for (int b = In[k + 1]; b < Fn[k + 1]; b++)
                        {
                            if (Tab2[i, j] != 0)
                            {
                                if (Tab2[a, b] == 0)
                                {
                                    if (valoresPossiveis[a, b].Contains(Tab2[i, j]))
                                    {
                                        for (int c = 0; c < valoresPossiveis[a, b].Count; c++)
                                        {
                                            if (valoresPossiveis[a, b][b] == Tab2[i, j])
                                                valoresPossiveis[a, b].Remove(valoresPossiveis[a, b][c]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (Tab2[i, j] == 0)
                {
                    if (valoresPossiveis[i, j].Count == 1)
                        Tab2[i, j] = valoresPossiveis[i, j][0];
                }

            }
        }


    }

}


