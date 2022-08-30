using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E_Buttons : MonoBehaviour
{
    public void 공약수()
    {
        SceneManager.LoadScene("공약수설명");
    }

    public void 최대공약수()
    {
        SceneManager.LoadScene("최대공약수설명");
    }

    public void 분수약분()
    {
        SceneManager.LoadScene("분수약분설명");
    }

    public void 최소공배수()
    {
        SceneManager.LoadScene("최소공배수설명");
    }

    public void 소인수분해()
    {
        SceneManager.LoadScene("소인수분해설명");
    }

    public void 약수()
    {
        SceneManager.LoadScene("약수설명");
    }

    public void 세수약분()
    {
        SceneManager.LoadScene("세수약분설명");
    }

    public void 사칙연산()
    {
        SceneManager.LoadScene("사칙연산설명");
    }
}
