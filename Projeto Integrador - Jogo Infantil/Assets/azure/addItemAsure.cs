using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;

public class addItemAsure : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Upload());
    }

    private static AlunoID CriarJsonDeAlunoID()
    {
        AlunoID aluno = new AlunoID(5, "", new int[1] { 10 }, 5, "Abhner", System.DateTime.Now, "3B", 2002650, 1, "65652");

        return aluno;
    }

    private static Resultado CriarResultado()
    {
        Resultado resultado = new Resultado(9, null, null, 10, System.DateTime.Now.Date, System.DateTime.Now.TimeOfDay, 2, 1, 30, 20, 10, 50);

        return resultado;
    }

    IEnumerator Upload()
    {
        AlunoID aluno = CriarJsonDeAlunoID();

        string meuJson = JsonConvert.SerializeObject(aluno);

        //Resultado resultado = CriarResultado();

        //string meuJson = JsonConvert.SerializeObject(resultado);
        
        Debug.Log(meuJson);

        //MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(meuJson));

        //byte[] bit = Encoding.UTF8.GetBytes(meuJson);

        WWWForm form = new WWWForm();
        //form.AddBinaryData("meuTesteJsonEmBinary", memoryStream.ToArray());
        form.AddField("meuCampo", meuJson);


        using (UnityWebRequest www = UnityWebRequest.Post("https://pi3webgameapp.azurewebsites.net/api/ApiAlunos", form))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.uploadHandler.contentType = "application/json";

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log("Form upload complete!");
            }
        }

        //memoryStream.Dispose();
    }
}
