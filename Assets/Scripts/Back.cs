using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public int Before;
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) //뒤로가기 키 입력
            {
                if(SceneManager.GetActiveScene().name == "Main") {
                    Application.Quit();
                } else {
                    SceneManager.LoadScene(Before);
                }
            }
        }
    }
}
