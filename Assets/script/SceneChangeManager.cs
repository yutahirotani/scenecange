using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {

    // シーンを遷移する
    public static void SceneChange(string NextScene)
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);    // 次のシーンへ遷移
    }
}
