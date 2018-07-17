using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GotoNextScene : MonoBehaviour
{

    public static string NextScene;       // 次のシーン

    [SerializeField]
    private string sceneName = "Top";

    // Update is called once per frame
    void Update()
    {
        if( SceneFadeManager._fade_sequence == 1)
        {
            NextScene = sceneName;
            // フェードアウト開始
            //SceneFadeManager._fade_sequence = 2;
        }
        // 次のシーンへ遷移する
        if (SceneFadeManager._fade_sequence == 4)
        {
            SceneChangeManager.SceneChange(NextScene);
            SceneFadeManager._fade_sequence = 5;
        }
    }

    // タッチしたらフェードアウトを呼ぶ
    public void onTouchGotoFadeOut(string Next)
    {
        // フェードインが終わっていたら
        if (SceneFadeManager._fade_sequence == 1)
        {
            // 次のシーンへ
            NextScene = Next;
            // フェードアウト開始
            SceneFadeManager._fade_sequence = 2;
        }
    }
}