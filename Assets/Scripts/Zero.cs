using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Zero : MonoBehaviour
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
        if(EventSystem.current.currentSelectedGameObject != this.gameObject) {
            if(int.Parse(tex.text) < 3) {
                tex.text = "";
            }
        }
    }
}
