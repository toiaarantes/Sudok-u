﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogo : MonoBehaviour {
    public int[,,] Tab2 = new int[3, 3, 2];

    // Use this for initialization
    void Start() {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Tab2[i, j, 0] = i+j;
                Debug.Log("Tab=");
                Debug.Log(Tab2[i,j,0]);
                Debug.Log("i=");
                Debug.Log(i);
                Debug.Log("j=");
                Debug.Log(j);

            }
        }
    }
        // Update is called once per frame
        void Update() {

        }

        public bool Preencher(int i, int j)
        {
            if (i==j)
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
