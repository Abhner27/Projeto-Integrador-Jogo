using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pedido : MonoBehaviour
{
    //toda fruta tem uma cor e seu nome
    //escolher quantidade (max 7 frutas total)!

    [SerializeField]
    private TextMeshProUGUI texto;

    [SerializeField]
    private VerificadorFrutas verificadorFrutas;

    private static fruta maca = new fruta("maçã", "<#FF0000>", 0);
    private static fruta pera = new fruta("pêra", "<#BEDC3E>", 1);
    private static fruta abacaxi = new fruta("abacaxi", "<#FCDB5B>", 2);
    private static fruta melancia = new fruta("melancia", "<#38722D>",3);
    private static fruta morango = new fruta("morango", "<#ED4E4D>",4);
    private static fruta uva = new fruta("uva", "<#8A5BA2>",5);

    private static List<fruta> frutas = new List<fruta>(6)
    {
        maca, pera, abacaxi, melancia, morango, uva
    };

    int frutaEscolhida = 0;

    private void Start()
    {
        NovoPedido(Random.Range(1, 4));
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
            NovoPedido(Random.Range(1, 4));
    }

    public void NovoPedido(int quantDePedidos)
    {
        texto.text = "Separe ";

        verificadorFrutas.resetarParaPedido();

        for (int i = 0; i < quantDePedidos; i++)
        {
            if (i > 0 && i + 1 == quantDePedidos)
                texto.text += " e ";
            else if (i > 0)
                texto.text += ", ";

            string parte = retornarPartePedido();

            frutas.RemoveAt(frutaEscolhida);

            texto.text += parte;
        }

        ResetListaDeFrutas();
    }

    private string retornarPartePedido()
    {
        int quantidade = Random.Range(1, 4);
        frutaEscolhida = Random.Range(0, frutas.Count);

        verificadorFrutas.receberUmNovoPedido(quantidade, frutas[frutaEscolhida].id);

        string s = string.Empty;

        if (quantidade > 1)
            s = "s";

        return frutas[frutaEscolhida].cor + quantidade + " " + frutas[frutaEscolhida].nome + s + "</color>";
    }

    private void ResetListaDeFrutas()
    {
        frutas.Clear();

        frutas.Add(maca);
        frutas.Add(pera);
        frutas.Add(abacaxi);
        frutas.Add(melancia);
        frutas.Add(morango);
        frutas.Add(uva);
    }
}
