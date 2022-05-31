using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PedidosFrutasUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMacas;
    [SerializeField]
    TextMeshProUGUI textUvas;
    [SerializeField]
    TextMeshProUGUI textAbacaxis;
    [SerializeField]
    TextMeshProUGUI textMelancias;
    [SerializeField]
    TextMeshProUGUI textMorangos;
    [SerializeField]
    TextMeshProUGUI textPeras;

    private Dictionary<pedidoDeFrutas , TextMeshProUGUI> textsDictionary = new Dictionary<pedidoDeFrutas, TextMeshProUGUI>(6);

    private void Start()
    {
        textsDictionary.Add(frutas.macas, textMacas);
        textsDictionary.Add(frutas.uvas, textUvas);
        textsDictionary.Add(frutas.abacaxis, textAbacaxis);
        textsDictionary.Add(frutas.melancias, textMelancias);
        textsDictionary.Add(frutas.morangos, textMorangos);
        textsDictionary.Add(frutas.peras, textPeras);

        PedidosFrutas.atualizarUI += atualizarUI;
    }

    public void atualizarUI()
    {
        //Se é 0, deixa inatvo o gameObject!
        //Se completou, muda a cor para verde

        foreach (pedidoDeFrutas pedido in frutas.pedidos)
        {
            if (pedido.quantRequerida == 0)
            {
                textsDictionary[pedido].transform.parent.gameObject.SetActive(false);
                continue;
            }
            else
            {
                textsDictionary[pedido].transform.parent.gameObject.SetActive(true);
            }

            if (pedido.quantAtual == pedido.quantRequerida)
            {
                textsDictionary[pedido].color = Color.green;
            }
            else
            {
                textsDictionary[pedido].color = Color.white;
            }

            textsDictionary[pedido].text = pedido.quantAtual + " / " + pedido.quantRequerida;
        }
    }

    private void OnDestroy()
    {
        PedidosFrutas.atualizarUI -= atualizarUI;
    }
}
