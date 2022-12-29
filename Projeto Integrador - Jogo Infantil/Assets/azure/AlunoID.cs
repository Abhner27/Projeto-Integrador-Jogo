using UnityEngine;

[System.Serializable]
public class AlunoID
{
    public int id;
    public string deficiencia;
    public int[] resultados;
    public int alunoID;
    public string nome;
    public System.DateTime nascimento;
    public string turma;
    public int matricula;
    public int deficienciaID;
    public string senha;

    public AlunoID(int id, string deficiencia, int[] resultados, int alunoID, string nome, System.DateTime nascimento, string turma, int matricula, int deficienciaID, string senha)
    {
        this.id = id;
        this.deficiencia = deficiencia;
        this.resultados = resultados;
        this.alunoID = alunoID;
        this.nome = nome;
        this.nascimento = nascimento;
        this.turma = turma;
        this.matricula = matricula;
        this.deficienciaID = deficienciaID;
        this.senha = senha;
    }
}
