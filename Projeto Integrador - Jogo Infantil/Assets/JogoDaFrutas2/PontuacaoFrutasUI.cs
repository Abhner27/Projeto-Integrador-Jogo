using UnityEngine;
using TMPro;

public class PontuacaoFrutasUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPontos;

    private void Start()
    {
        PontuacaoFrutas.atualizarUI += atualizarUI;
    }

    public void atualizarUI(int pontos)
    {
        textPontos.text = pontos.ToString();
    }

    private void OnDestroy()
    {
        PontuacaoFrutas.atualizarUI -= atualizarUI;
    }
}

