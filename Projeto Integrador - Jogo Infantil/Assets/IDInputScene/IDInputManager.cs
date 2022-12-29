using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class IDInputManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _idText;


    public void AddItem(string numero)
    {
        _idText.text += numero;
    }

    public void DeletarItem()
    {
        if (_idText.text.Length == 0)
            return;

        string texto = _idText.text;
        _idText.text = "";

        for (int i = 0; i < texto.Length - 1; i++)
        {
            _idText.text += texto[i].ToString();
        } 
    }

    public void Entrar()
    {
        AlunoID aluno = azure.VerificarEretornarID(_idText.text);

        //caso  o ID seja valido, entra no jogo e salva esse ID
        if (aluno == null)
        {
            Debug.Log("Id não existente!");

            //reeta texto
            _idText.text = "";

            //Aparece um erro
            return;
        }

        Debug.Log("ID encontrado!");
        //Bem vindo "fulano de tal"!
        Debug.Log("Bem vindo " + aluno.nome + "!");
        //carrega jogo!
        IDAluno.id = aluno.alunoID;
        SceneManager.LoadScene(1);
    }
}

public static class IDAluno
{
    public static int id;
}