using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomComment : MonoBehaviour
{
    //For the Position of the KeyBoard
    [SerializeField] private GameObject buttonTable;
    [SerializeField] private TMP_Text textDisplayTable;
    [SerializeField] private TMP_InputField inputText;
    public void StartEventInput()
    {
        inputText.onValueChanged.AddListener(UpdateText);
    }
    public void SaveComment()
    {
       textDisplayTable.text = inputText.text;
       inputText.onValueChanged.RemoveListener(UpdateText);
    }
    void UpdateText(string inputText)
    {
        textDisplayTable.text = inputText;
    }
    private void OnDestroy()
    {
        Debug.Log("Yeah Object Destroy");
       textDisplayTable.text = inputText.text;
       inputText.onValueChanged.RemoveListener(UpdateText);
    }
}
