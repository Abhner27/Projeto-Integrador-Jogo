using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frutasManager : MonoBehaviour
{
    public Pedido pedido;
    public PontuacaoFrutas pontuacao;

    public static frutasManager instance;

    private void Awake()
    {
        instance = this;
    }

}
