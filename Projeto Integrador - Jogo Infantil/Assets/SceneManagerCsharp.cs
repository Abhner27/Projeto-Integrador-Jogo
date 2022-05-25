using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerCsharp : MonoBehaviour
{
    public static SceneManagerCsharp instance;
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void mudarParaCena(int i)
    {
        SceneManager.LoadScene(i);
    }

}
