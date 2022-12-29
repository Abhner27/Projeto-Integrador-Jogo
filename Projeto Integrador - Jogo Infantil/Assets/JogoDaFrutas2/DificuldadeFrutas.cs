using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificuldadeFrutas : MonoBehaviour
{
    public static float MaiorValorTempo;
    public static int QuantMaxPedidos;

    private void Awake()
    {
        MaiorValorTempo = 5f;
        QuantMaxPedidos = 2;
    }
}
