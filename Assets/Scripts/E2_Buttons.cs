using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E2_Buttons : MonoBehaviour
{
    public void 근의개수()
    {
        SceneManager.LoadScene("근의개수설명");
    }

    public void 근의공식()
    {
        SceneManager.LoadScene("근의공식설명");
    }

    public void 내각의합()
    {
        SceneManager.LoadScene("내각의합설명");
    }

    public void 대각선의총개수()
    {
        SceneManager.LoadScene("대각선의총개수설명");
    }

    public void 소수합성수판별()
    {
        SceneManager.LoadScene("소수합성수판별설명");
    }

    public void 순환소수유리화()
    {
        SceneManager.LoadScene("순환소수유리화설명");
    }

    public void 유리화()
    {
        SceneManager.LoadScene("유리화설명");
    }

    public void 피타고라스의정리()
    {
        SceneManager.LoadScene("피타고라스설명");
    }
}
