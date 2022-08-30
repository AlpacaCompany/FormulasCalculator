using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Linq;

public class Formulas : MonoBehaviour
{
    float AddNum;
    float AddX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //MathNUM(1 , 2 , 3);
        소인수분해(50f);
        소인수분해(100f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("k")) {
            //Test Area
            Debug.Log(일차방정식("x +5 = 8")[0]);
            Debug.Log(일차방정식("x +5 = 8")[1]);
        }  

    }
    
    public List<Vector2> 일차함수(string 기울기 , float 절편) {
        Vector2 Fir = new Vector2(0 , 0);
        Vector2 Sec = new Vector2(0, 0);
        if(사칙연산(기울기) % 1 == 0) { //정수
            Fir = new Vector2(0 , 절편);
            Sec = new Vector2(1, 절편 + float.Parse(기울기));
        } else { //분수(소수)
            List<string> list = 기울기.Split('/').ToList();
            Fir = new Vector2(0, 절편);
            Debug.Log(list[1]);
            Sec = new Vector2(float.Parse(list[1]), 절편 + float.Parse(list[0]));
        }
        List<Vector2> ans = new List<Vector2>();
        ans.Add(Fir); ans.Add(Sec);
        return ans;
    }

    public List<float> 순환소수유리화(float a , float b) { //1.95 -> a: 1.9 b: 5 받을때는 a : 19 b : 5
        float c = 0;
        if(a == 0) {
            c = 0;
            a = 0;
        } else {
            c = float.Parse(a.ToString().Split('.')[1]); // 9
            a = float.Parse(a.ToString().Split('.')[0] + a.ToString().Split('.')[1]);
        }
        string 분자 = a.ToString() + b.ToString(); // 분자 = 195
        string 분모 = "";
        for(int i = 0; i < Mathf.Floor(Mathf.Log10(b) + 1); i++) {
            분모 += "9"; //9분에
        }
        for (int i = 0; i < Mathf.Floor(Mathf.Log10(c) + 1); i++)
        {
            분모 += "0"; //90분에
        }
        분자 = (float.Parse(분자) - a).ToString();
        List<float> list = 분수약분(float.Parse(분자) , float.Parse(분모)).ToList();
        return list;
    }

    public string 소수합성수판별(float N) { // ㅇ... 자연수만 되게 해놔
        if(약수계산기(N).Count == 2) {
            return "소수";
        } else if(약수계산기(N).Count <= 1) {
            return "1 과 0 그리고 음수는 소수 , 합성수중 무엇도 아닙니다.";
        } else {
            return "합성수";
        }
    }

    public float 최소공배수(float a , float b) { // 4 , 8

        float one = 최대공약수(a , b); // 4
        float two = a / one; //1
        float three = b / one; // 2
        return one * two * three;
    }
    
    public List<float> 공약수(float a, float b) {
        List<float> AList = 약수계산기(a); //[1, 2, 3, 4, 6, 12]
        List<float> BList = 약수계산기(b); //[1, 2, 4, 8]
        List<float> Same = AList.Intersect(BList).ToList();
        return Same;
    }

    public float 최대공약수(float a , float b) {
        List<float> AList = 약수계산기(a); //[1, 2, 3, 4, 6, 12]
        List<float> BList = 약수계산기(b); //[1, 2, 4, 8]
        List<float> Same = AList.Intersect(BList).ToList();
        return Same[Same.Count -1];
    }

    public float 근의개수(float a, float b, float c) {
        var ans = (b*b) - 4*a*c; // 0 1 1
        if(ans > 0) {
            return 2;
        } else if(ans == 0) {
            return 1;
        } else {
            return 0;
        }
    }

    public float[] 일차방정식(string sic) { // "3 +5 = 8"
        AddNum = 0;
        AddX = 0;
        string Left = sic.Split('=')[0]; // "3 +5 "
        string Right = sic.Split('=')[1]; // " 8"

        List<string> LeftTerms = new List<string>();
        LeftTerms.AddRange(Left.Split(' ')); // ["3" , "+5" , ""] 
        LeftTerms.Remove("");

        List<string> RightTerms = new List<string>();
        RightTerms.AddRange(Right.Split(' ')); //["" , "8"]
        RightTerms.Remove("");
        
        for(int i = 0; i < LeftTerms.Count; i ++) {
            if(LeftTerms[i].Contains("x")) {
                LeftTerms[i] = LeftTerms[i].Substring(0 , LeftTerms[i].Length - 1);
            } else {
                AddNum += float.Parse(LeftTerms[i]);
                LeftTerms[i] = "";
                
            }
        }
        LeftTerms.Remove("");
        RightTerms.Add((-AddNum).ToString());

        for (int j = 0; j < RightTerms.Count; j++) {
            if (RightTerms[j].Contains("x")) {
                AddX += float.Parse(RightTerms[j].Substring(0, LeftTerms[j].Length - 1));
                RightTerms[j] = "";
            } else { 
            }
        }
        RightTerms.Remove("");
        LeftTerms.Add((-AddX).ToString());

        List<float> LeftTermsF = LeftTerms.ConvertAll(s => float.Parse(s));
        List<float> RightTermsF = RightTerms.ConvertAll(s => float.Parse(s)); // [1] [-1]
        
        float up = RightTermsF.Sum();
        float down = LeftTermsF.Sum();
        float[] arr = {up, down};
        arr = 분수약분(arr[0] , arr[1]);
        return arr;
    }

    public float[] 분수약분(float 분자 , float 분모) {
        List<float> DivisorList = new List<float>();
        DivisorList.AddRange(약수계산기(분자).ToArray());
        DivisorList.AddRange(약수계산기(분모).ToArray());
        DivisorList = DivisorList.Distinct().ToList();
        List<float> PossibleList = new List<float>();

        for(int i = 0; i < DivisorList.Count; i++) {
            if(분자 % DivisorList[i] == 0 && 분모 % DivisorList[i] == 0) {
                PossibleList.Add(DivisorList[i]);
            }
        }
        float MaxInt = PossibleList[PossibleList.Count - 1];
        float[] FinalArr = {분자 / MaxInt, 분모 / MaxInt};
        return FinalArr;
    }  

    public string[] 근의공식(float a, float b, float c) { //1 2 1
        float 제곱수 = 작업용유리화(Mathf.Pow(b, 2) - (4 * a * c))[0]; //0
        float 나머지 = 작업용유리화(Mathf.Pow(b, 2) - (4 * a * c))[1]; //0
        string 분모 = (2 * a).ToString(); //2
        string 분자1 = (-b).ToString(); //-2
        string 분자2 = "";
        if(제곱수 == 1 || float.Parse(분자1) == 0|| float.Parse(분모) == 0) {
        } else {
                List<float> List = 세수약분(float.Parse(분자1) , 제곱수, float.Parse(분모));
            분자1 = List[0].ToString();
            제곱수 = List[1];
            분모 = List[2].ToString();
        }
        if (float.Parse(분자1) == 0) {
            분자1 = "";
        }
        if(나머지 == 0 && 제곱수 == 1) {
            float[] arr = 분수약분(float.Parse(분자1) , float.Parse(분모));
            분자1 = arr[0].ToString();
            분모 = arr[1].ToString();
            분자2 = " (중근)";
        } else if(제곱수 == 1) {
            if(나머지 < 0) {
                분자2 = $" ± √{나머지.ToString()} (실수해없음)";
            } else {
                분자2 = $" ± √{나머지.ToString()}";
            }
            
        } else if(나머지 == 1) {
            분자2 = $" ± {제곱수.ToString()}";
        } else {
            분자2 = $" ± {제곱수.ToString()}√{나머지.ToString()}";
        } 
        string 분자 = 분자1 + 분자2;
        string[] Arr = {분자 , 분모};
        return Arr;
    }

    public string 소인수분해(float reqired) {
        string 소인수분해답 = "";
            float[] Arr = {2f, 3f, 5f, 7f, 11f, 13f, 17f, 19f, 23f, 29f, 31f, 37f, 41f, 43f, 47f, 53f, 59f, 61f, 67f, 71f, 73f, 79f, 83f, 89f, 97f};
            for(int i = 0;i < Arr.Length; i++) {
                while((reqired / Arr[i]).ToString().Contains(".") == false) {
                    reqired = reqired / Arr[i];
                    소인수분해답 = 소인수분해답 + "+" + Arr[i].ToString() + " x ";
                }
            }
            소인수분해답 = 소인수분해답.Substring(0 , 소인수분해답.Length - 2);
            return 소인수분해답;
    }

    public List<float> 약수계산기(float reqired) {
        List<float> list = new List<float>();
        for(int i = 0; i < reqired + 1; i++) {
            if(reqired % i == 0) {
                list.Add(i);
                //list.Add(-i); - 부분
            }
        }
        return list;
    }

    public List<int> 개선소인수분해(float reqired) {
            List<int> Slist = new List<int>();
            int diviser = 2;
            if(reqired == 0) {
                Slist.Add(0);
            } else {
                while(reqired != 1) {
            if(reqired % diviser == 0) {
                Slist.Add(diviser);
                reqired /= diviser;
            } else {
                diviser++;
            }
        }
    }
            
        return Slist;
    }

    public string 유리화(float root) {
        bool tf = true;
        if(root < 0) {
            root = -root;
            tf = false;
        }
        var dic = new Dictionary<float , float> () {};
        List<int> List = 개선소인수분해(root); // [2 , 2]
        for(int i = 0; i < List.Count; i++) {
            if(dic.ContainsKey(List[i])) {
                dic[List[i]] += 1;
            } else {
                dic.Add(List[i] , 1);
            }
        } // 뭐가 몇개있는지에 대한 딕셔너리 생성 2: 2
        List<float> keyList = new List<float>(dic.Keys); // 키들을 리스트로 정리 2
        float 나머지 = 1;
        float 제곱수 = 1;
        for(int j = 0; j < keyList.Count; j++) {
            float ou = 0;
            
            dic.TryGetValue(keyList[j] , out ou); // 리스트에 벨류 받아오기 예: 2 에 2개
            if(ou > 1) {
                if(ou % 2 == 1) { //제곱수가 아님 2가 3개나 5개 , 7개 씩 있는경우
                    나머지 *= keyList[j]; // 나머지 *= 2
                    제곱수 *= Mathf.Sqrt(Mathf.Pow(keyList[j], ou -1)); // 5 - 1 = 4
                } else { //제곱수인경우
                    제곱수 *= Mathf.Sqrt(Mathf.Pow(keyList[j], ou));
                }
            } else {
                나머지 *= keyList[j]; 
            }
        }
        if(나머지 == 1) {
            if(!tf) {
                return "-" + 제곱수.ToString();
            } else {
                return 제곱수.ToString();
            }
            
        } else if (제곱수 == 1) {
            if(!tf) {
                return "-√" + 나머지.ToString();
            } else {
                return "√" + 나머지.ToString();
            }
        } else {
            if(!tf) {
                return "-" + 제곱수.ToString() + "√" + 나머지.ToString();
            } else {
                return 제곱수.ToString() + "√" + 나머지.ToString();
            }
        }
    }

    public float[] 작업용유리화(float root){
        bool tf = true;
        if(root < 0) {
            root = -root;
            tf = false;
        }
        var dic = new Dictionary<float, float>() { };
        List<int> List = 개선소인수분해(root); // [2 , 2]
        for (int i = 0; i < List.Count; i++)
        {
            if (dic.ContainsKey(List[i]))
            {
                dic[List[i]] += 1;
            }
            else
            {
                dic.Add(List[i], 1);
            }
        } // 뭐가 몇개있는지에 대한 딕셔너리 생성 2: 2
        List<float> keyList = new List<float>(dic.Keys); // 키들을 리스트로 정리 2
        float 나머지 = 1;
        float 제곱수 = 1;
        for (int j = 0; j < keyList.Count; j++)
        {
            float ou = 0;

            dic.TryGetValue(keyList[j], out ou); // 리스트에 벨류 받아오기 예: 2 에 2개
            if (ou > 1)
            {
                if (ou % 2 == 1)
                { //제곱수가 아님 2가 3개나 5개 , 7개 씩 있는경우
                    나머지 *= keyList[j]; // 나머지 *= 2
                    제곱수 *= Mathf.Sqrt(Mathf.Pow(keyList[j], ou - 1)); // 5 - 1 = 4
                }
                else
                { //제곱수인경우
                    제곱수 *= Mathf.Sqrt(Mathf.Pow(keyList[j], ou));
                }
            }
            else
            {
                나머지 *= keyList[j];
            }
        }
        if(!tf) {
            float[] Arr1 = {1, -root};
            return Arr1;
        } else {
            float[] Arr2 = {제곱수 , 나머지};
            return Arr2;
        }
    }

    public float 사칙연산(string 식) {
        DataTable dt = new DataTable();
        var 답 = dt.Compute(식 , "");
        return float.Parse(답.ToString());
    }

    public float 피타고라스의정리(float 첫번째변 , float 두번째변) {
        return (첫번째변 * 첫번째변) + (두번째변 * 두번째변);
    }

    public float 대각선총개수구하기(int 꼭짓점) {
        return (꼭짓점 * (꼭짓점 - 3) ) * 0.5f;
    }

    public float 내각의합구하기(int 꼭짓점) {
        return 180 * (꼭짓점 - 2);
    }

    public float 완전제곱식(float a , float b) {
        return (a*a) + (2 * a * b) + (b*b);
    }

    public float 합차(float a, float b) {
        return (a + b) * (a - b);
    }

    public float 합곱(float a ,float b, float c) {
        return (a*a) + a*(b+c) + (b*c);
    }

    public List<float> 세수약분(float a , float b , float c) { //-4 2 2
        List<float> ab = 공약수(Mathf.Abs(a), Mathf.Abs(b)); //[1,2,4]
        List<float> ac = 공약수(Mathf.Abs(a), Mathf.Abs(c)); //[1,2,4]
        List<float> bc = 공약수(Mathf.Abs(b), Mathf.Abs(c)); //[1,2,4,8]
        List<float> Same1 = ab.Intersect(ac).ToList(); // [1,2,4]
        List<float> Same2 = ab.Intersect(bc).ToList(); // [1,2,4]
        List<float> Same3 = ac.Intersect(bc).ToList(); // [1,2,4]
        float ins = Same1[Same1.Count - 1];
        float[] arr = {a/ins , b / ins, c / ins};
        
        if(a < 0) {
            arr[0] = (a/ins);
        }
        if (b < 0)
        {
            arr[1] = (b / ins);
        }
        if (c < 0)
        {
            arr[2] = (c / ins);
        }
        List<float> result = arr.ToList();
        return result;
    }

} //삼각형넓이 , 사각형넓이 , 사다리꼴넓이 , 원의넓이 , 원의둘레 , 마름모넓이 , 부채꼴의호와넓이, 속력 , 시간 , 거리 , 최대공약수, 최소공배수, 공약수 , 사칙연산 , 소인수분해 , 분수약분 
 // 피타고라스, 한꼭짓점에서생기는대각선의개수, 대각선총개수, 내각의합, 대각선그어생기는삼각형개수 ,뿔의부피, 기둥의부피 , 구의부피 , 구의겉넓이 , 완전제곱식, 합차 , 합곱 , 유리화 ,  약수 , 근의공식 ,순환소수유리화 , 일차함수, 일차방정식 , 근의개수
 // 
 //
