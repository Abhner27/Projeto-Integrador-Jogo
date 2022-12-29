using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class azure : MonoBehaviour
{
    public static AlunoID[] alunos;
    void Start()
    {
        // A pagina de alunos
        StartCoroutine(GetRequest("https://pi3webgameapp.azurewebsites.net/api/ApiAlunos"));
        //StartCoroutine(GetRequest("https://pi3webgameapp.azurewebsites.net/api/APIDeficiencias1"));
        //StartCoroutine(GetRequest("https://pi3webgameapp.azurewebsites.net/api/APIResultadoJogadas"));
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Requisitar e esperar resposta da WEB
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                alunos = JsonConvert.DeserializeObject<AlunoID[]>(webRequest.downloadHandler.text);
            }
        }
    }

    public static AlunoID VerificarEretornarID(string id)
    {
        Debug.Log("ID entrado: " + id);

        foreach (AlunoID aluno in alunos)
        {
            if (aluno.alunoID.ToString() == id)
                return aluno;
        }
        return null;
    }
}