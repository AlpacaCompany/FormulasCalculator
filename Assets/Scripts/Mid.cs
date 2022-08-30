using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mid : MonoBehaviour
{
    public TMP_InputField Input1;
    public TMP_InputField Input2;
    public TMP_InputField Input3;
    
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public Formulas mula;

    public void 공약수() { //초
        Text1.text = "결과: ";
        int A = int.Parse(Input1.text);
        int B = int.Parse(Input2.text);
        List<float> List = mula.공약수(A,B);
        for(int i = 0;i < List.Count; i++) {
            Text1.text += List[i].ToString() + " ";
        }
    }

    public void 최대공약수() { //초
        Text1.text = "결과 :";
        float A = float.Parse(Input1.text);
        float B = float.Parse(Input2.text);
        Text1.text = "결과 : " + mula.최대공약수(A , B).ToString();
    }

    public void 분수약분() { //초
        float A = float.Parse(Input1.text);
        float B = float.Parse(Input2.text);

        float[] Arr = mula.분수약분(A , B);
        float 분자 = Arr[0];
        float 분모 = Arr[1];
        Text1.text = 분자.ToString();
        Text2.text = 분모.ToString();
    }

    public void 최소공배수() //초
    {
        Text1.text = "결과 :";
        float A = float.Parse(Input1.text);
        float B = float.Parse(Input2.text);
        Text1.text = "결과 : " + mula.최소공배수(A, B).ToString();
    }

    public void 사칙연산() { //초
        
        Text1.text = "결과 : " + mula.사칙연산(Input1.text).ToString();
    }

    public void 소인수분해() { //초
        List<int> List = mula.개선소인수분해(float.Parse(Input1.text));
        string text = "";
        for(int i = 0; i < List.Count; i++) {
            text += " " + List[i].ToString();
        }
        Text1.text = "결과 : " + text;
    }

    public void 약수() { //초
        List<float> List = mula.약수계산기(float.Parse(Input1.text));
        string text = "";
        for (int i = 0; i < List.Count; i++)
        {
            text += " " + List[i].ToString();
        }
        Text1.text = "결과 : " + text;
    }

    public void 근의개수() {
        float a = float.Parse(Input1.text);
        float b = float.Parse(Input2.text);
        float c = float.Parse(Input3.text);
        Text1.text = "결과 : " + mula.근의개수(a, b, c).ToString() + " 개";
    }

    public void 세수약분() { //초
        float a = float.Parse(Input1.text);
        float b = float.Parse(Input2.text);
        float c = float.Parse(Input3.text);
        List<float> List = mula.세수약분(a,b,c);
        string txt = "결과 : ";
        txt += "  A : " + List[0].ToString(); txt += "  B : " + List[1].ToString(); txt += "  C : " + List[2].ToString();
        Text1.text = txt;
    }

    public void 근의공식() {
        float a = float.Parse(Input1.text);
        float b = float.Parse(Input2.text);
        float c = float.Parse(Input3.text);
        string[] arr = mula.근의공식(a,b,c);
        Text1.text = arr[0];
        Text2.text = arr[1];
    }

    public void 순환소수유리화() {
        float A = float.Parse(Input1.text);
        float B = float.Parse(Input2.text);
        List<float> List = mula.순환소수유리화(A , B);
        Text1.text = List[0].ToString();
        Text2.text = List[1].ToString();
    }

    public void 소수합성수() {
        float A = float.Parse(Input1.text);
        string N = mula.소수합성수판별(A);
        Text1.text = "결과 : " + N;
    }

    public void 유리화() {
        float A = float.Parse(Input1.text);
        Text1.text = "결과 : " + mula.유리화(A);
    }

    public void 대각선총개수() {
        int A = int.Parse(Input1.text);
        float N = mula.대각선총개수구하기(A);
        Text1.text = "결과 : " + N.ToString();
    }

    public void 내각의합() {
        int A = int.Parse(Input1.text);
        float N = mula.내각의합구하기(A);
        Text1.text = "결과 : " + N.ToString() + "°"; 
    }

    public void 피타고라스() {
        float A = float.Parse(Input1.text);
        float B = float.Parse(Input2.text);
        float N = mula.피타고라스의정리(A , B);
        Text1.text = "빗변(c) : " + mula.유리화(N);
    }

}
