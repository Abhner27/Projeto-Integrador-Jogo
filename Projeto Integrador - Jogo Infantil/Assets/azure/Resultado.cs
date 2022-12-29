using System;

[System.Serializable]
public class Resultado
{
    public int id;
    public object aluno;
    public object jogo;
    public int resultadoId;
    public DateTime dia;
    public TimeSpan hora;
    public int alunoID;
    public int jogoID;
    public int tempoJogada;
    public int acertos;
    public int erros;
    public int pontuacao;

    public Resultado(int id, object aluno, object jogo, int resultadoId, DateTime dia, TimeSpan hora, int alunoID, int jogoID, int tempoJogada, int acertos, int erros, int pontuacao)
    {
        this.id = id;
        this.aluno = aluno;
        this.jogo = jogo;
        this.resultadoId = resultadoId;
        this.dia = dia;
        this.hora = hora;
        this.alunoID = alunoID;
        this.jogoID = jogoID;
        this.tempoJogada = tempoJogada;
        this.acertos = acertos;
        this.erros = erros;
        this.pontuacao = pontuacao;
    }
}