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

    public void verificar(int ID)
    {
        if (frutas.pedidos[ID].quantAtual >= frutas.pedidos[ID].quantRequerida) //perde pontos?
            return;

        PedidosFrutas.addFruta(frutas.pedidos[ID]);
        //addPontos!
    }
}
