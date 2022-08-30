using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Two : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<TMP_InputField>().text != "") {
            if(int.Parse(GetComponent<TMP_InputField>().text) == 0 || int.Parse(GetComponent<TMP_InputField>().text) == 1 || int.Parse(GetComponent<TMP_InputField>().text) == 2) {
            GetComponent<TMP_InputField>().text = "";
        } else {
        }
        } else {
        }
        
    }
}
