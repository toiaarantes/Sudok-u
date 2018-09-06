using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogo : MonoBehaviour {
    public int[,,] Tab = new int[9, 9, 2];

    // Use this for initialization
    void Start() {
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
    }
        // Update is called once per frame
        void Update() {

        }

        public bool Preencher(int i, int j)
        {
            if (Tab[i, j, 1] == 1)
                return true;
            else
                return false;
        }

        public int Valor(int i, int j)
        {
            return Tab[i, j, 0];
        }
    }
