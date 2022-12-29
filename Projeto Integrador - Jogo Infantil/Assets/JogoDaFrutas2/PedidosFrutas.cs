using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedidosFrutas : MonoBehaviour
{
    public delegate void AtualizarUI();
    public static event AtualizarUI atualizarUI;

    private void Start()
    {
        frutas.Inicializar();

        foreach (pedidoDeFrutas pedido in frutas.pedidos)
        {
            EscolherValores(pedido);
        }

        atualizarUI?.Invoke();
    }

    private static void EscolherValores(pedidoDeFrutas pedido)
    {
        pedido.quantRequerida = Random.Range(0, DificuldadeFrutas.QuantMaxPedidos);
    }

    public static void addFruta(pedidoDeFrutas pedido)
    {
        pedido.quantAtual++;

        atualizarUI?.Invoke();
    }

    public static void novoPedido()
    {
        foreach (pedidoDeFrutas pedido in frutas.pedidos)
        {
            pedido.quantAtual = 0;
            EscolherValores(pedido);
        }
        atualizarUI?.Invoke();
    }



    public static bool completou()
    {
        foreach (pedidoDeFrutas pedido in frutas.pedidos)
        {
            if (pedido.quantAtual != pedido.quantRequerida)
                return false;
        }
        return true;
    }
}

public static class frutas
{
    public static pedidoDeFrutas macas = new pedidoDeFrutas();
    public static pedidoDeFrutas uvas = new pedidoDeFrutas();
    public static pedidoDeFrutas peras = new pedidoDeFrutas();
    public static pedidoDeFrutas morangos = new pedidoDeFrutas();
    public static pedidoDeFrutas melancias = new pedidoDeFrutas();
    public static pedidoDeFrutas abacaxis = new pedidoDeFrutas();

    public static pedidoDeFrutas[] pedidos = new pedidoDeFrutas[6]
    {
        macas, abacaxis, melancias, morangos, peras, uvas
    };

    public static void Inicializar()
    {
        macas.nome = "macas";
        uvas.nome = "uvas";
        peras.nome = "peras";
        morangos.nome = "morangos";
        melancias.nome = "melancias";
        abacaxis.nome = "abacaxis";

        macas.quantAtual = 0;
        uvas.quantAtual = 0;
        peras.quantAtual = 0;
        morangos.quantAtual = 0;
        melancias.quantAtual = 0;
        abacaxis.quantAtual = 0;
    }
}

public class pedidoDeFrutas
{
    public string nome;
    public int quantAtual;
    public int quantRequerida;
}
