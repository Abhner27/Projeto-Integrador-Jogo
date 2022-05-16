using System.Collections;
using UnityEngine;
using TMPro;

public class BotoesLetras : MonoBehaviour
{
    [SerializeField]
    public char letra;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        text.text = letra.ToString();
    }
}
