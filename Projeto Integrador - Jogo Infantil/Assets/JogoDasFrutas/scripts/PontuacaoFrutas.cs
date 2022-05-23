using UnityEngine;
using TMPro;

public class PontuacaoFrutas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private int pontos = 0;

    public void AddPontos(int amount)
    {
        pontos += amount;
        atualizarTexto();
    }

    private void atualizarTexto()
    {
        text.text = "PONTOS: " + pontos.ToString();
    }

}