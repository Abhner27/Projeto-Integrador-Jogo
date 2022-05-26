using UnityEngine;
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

    private void Start()
    {
        PedidosFrutas.atualizarUI += atualizarUI;
    }

    public void atualizarUI()
    {
        textMacas.text = frutas.macas.quantAtual + " / " + frutas.macas.quantRequerida;
        textAbacaxis.text = frutas.abacaxis.quantAtual + " / " + frutas.abacaxis.quantRequerida;
        textMelancias.text = frutas.melancias.quantAtual + " / " + frutas.melancias.quantRequerida;
        textMorangos.text = frutas.morangos.quantAtual + " / " + frutas.morangos.quantRequerida;
        textPeras.text = frutas.peras.quantAtual + " / " + frutas.peras.quantRequerida;
        textUvas.text = frutas.uvas.quantAtual + " / " + frutas.uvas.quantRequerida;
    }

    private void OnDestroy()
    {
        PedidosFrutas.atualizarUI -= atualizarUI;
    }
}
