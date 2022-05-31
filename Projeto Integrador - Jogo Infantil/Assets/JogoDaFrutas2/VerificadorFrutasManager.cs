using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificadorFrutasManager : MonoBehaviour
{
    // 0 -  maça
    // 1 -  abacaxi
    // 2 -  melancia
    // 3 -  morango
    // 4 -  pera
    // 5 -  uvas

    [SerializeField]
    private PontuacaoFrutas pontuacao;

    public void verificar(int ID)
    {
        if (frutas.pedidos[ID].quantAtual >= frutas.pedidos[ID].quantRequerida) //perde pontos?
        {
            pontuacao.addPontos(-10);
            AudioManager.instance.PlaySound("Wrong");
            return;
        }

        PedidosFrutas.addFruta(frutas.pedidos[ID]);
        //addPontos!
        pontuacao.addPontos(10);
        AudioManager.instance.PlaySound("Pop", Random.Range(0.9f, 1.2f));

        if (PedidosFrutas.completou() == true)
        {
            PedidosFrutas.novoPedido();
            AudioManager.instance.PlaySound("Vitória");
            pontuacao.addPontos(100);
        }
    }
}

