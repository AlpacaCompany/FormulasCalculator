using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Plus : MonoBehaviour
{
    TMP_InputField tex;
    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != this.gameObject)
        {
            if (tex.text == "0")
            {
                tex.text = "";
            }
        }
    }
}
