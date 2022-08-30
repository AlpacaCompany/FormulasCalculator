using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void TStroy() {
        Application.OpenURL("https://alpaca-code.tistory.com/m");
    }

    public void Play_Store()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=7686711540221922902");
    }

    public void OpenSea() {
        Application.OpenURL("https://opensea.io/collection/the-cutemonster-nft-alpaca");
    }

    public void KakaoTalk()
    {
        Application.OpenURL("https://open.kakao.com/me/UnityLearn");
    }
}
