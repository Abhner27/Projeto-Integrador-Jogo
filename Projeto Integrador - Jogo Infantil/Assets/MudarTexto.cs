﻿using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MudarTexto : MonoBehaviour
{
    public Text texto;
    public string textoSalvo = "Abhner";

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);


    public static MudarTexto instance;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }







    public void hello()
    {
        Hello();
    }

    public void setText(string novoTexto)
    {
        texto.text = novoTexto;
    }

    public void JSLIBSetString(string novoTexto)
    {
        HelloString(novoTexto);
    }

    public void MudarParaCena(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void setJson(string json)
    {
        JasonObj jsonObj = JsonUtility.FromJson<JasonObj>(json);
        texto.text = "Nome " + jsonObj.nome + ", idade: " + jsonObj.idade;
    }

    public class JasonObj
    {
        public string nome;
        public int idade;
    }
}
