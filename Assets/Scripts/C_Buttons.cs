using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_Buttons : MonoBehaviour
{
    public void 공약수() {
        SceneManager.LoadScene("공약수");
    }

    public void 최대공약수()
    {
        SceneManager.LoadScene("최대공약수");
    }

    public void 분수약분()
    {
        SceneManager.LoadScene("분수약분");
    }

    public void 최소공배수()
    {
        SceneManager.LoadScene("최소공배수");
    }

    public void 소인수분해()
    {
        SceneManager.LoadScene("소인수분해");
    }

    public void 약수()
    {
        SceneManager.LoadScene("약수");
    }

    public void 세수약분()
    {
        SceneManager.LoadScene("세수약분");
    }

    public void 사칙연산()
    {
        SceneManager.LoadScene("사칙연산");
    }

    public void 초등학교() {
        SceneManager.LoadScene("C-first");
    }

    public void 중학교()
    {
        SceneManager.LoadScene("C-second");
    }
    
    public void 고등학교()
    {
        SceneManager.LoadScene("C-third");
    }
}
