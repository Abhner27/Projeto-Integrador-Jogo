using UnityEngine;

public class PontuacaoFrutas : MonoBehaviour
{
    public int Pontos = 0;

    public delegate void AtualizarUI(int pontos);
    public static event AtualizarUI atualizarUI;

    public void addPontos(int pontosParaAdd)
    {
        Pontos += pontosParaAdd;
        atualizarUI?.Invoke(Pontos);
    }
}

