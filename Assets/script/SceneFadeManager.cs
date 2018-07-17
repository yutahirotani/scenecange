﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeManager : MonoBehaviour {
    public static GameObject _fadeManager;
    public static Animator _fadeAnimator;
    public bool DontDestroyEnabled = true;
    public static int _fade_sequence = 0;     // フェードシーケンス
	// Use this for initialization
	void Start () {
        //_fade_sequence = 0;
        // 一つのオブジェクトだけを設定
        if (!_fadeManager)
        {
            // FadeBaseからFadeManagerを呼び出し
            _fadeManager = gameObject;
            _fadeManager.SetActive(true);   // アクティブにする
            // アニメーター取得
            _fadeAnimator = _fadeManager.GetComponent<Animator>();

            if (DontDestroyEnabled)
            {
                // Sceneを遷移してもオブジェクトが消えないようにする
                DontDestroyOnLoad(this);
            }
        }	
	}
	
	// Update is called once per frame
	void Update () {
        switch (_fade_sequence)
        {
            case 0:
                // フェードインアニメーション名を判定
                if (_fadeAnimator.GetCurrentAnimatorStateInfo(0).IsName("fadein"))
                {
                    // フェードインアニメーションの終了を検知
                    if (_fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        _fade_sequence = 1;

                    }
                }
                break;
            case 2:
                // アニメーションを呼び出す場合はuGUIの方でアニメーションをAnimatorに設定しておく必要がある
                _fadeAnimator.Play("fadeout",0,0.0f);
                _fade_sequence = 3;
                break;
            case 3:
                // フェードアウトアニメーション名を判定
                if (_fadeAnimator.GetCurrentAnimatorStateInfo(0).IsName("fadeout"))
                {
                    // フェードインアニメーションの終了を検知
                    if (_fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        _fade_sequence = 4;
                    }
                }
                break;
            case 4:
                // シーンを変更する
                //SceneChangeManager.SceneChange();
                //_fade_sequence = 5;
                break;
            case 5:
                // アニメーションを呼び出す場合はuGUIの方でアニメーションをAnimatorに設定しておく必要がある
                _fadeAnimator.Play("fadein", 0, 0.0f);
                _fade_sequence = 0;
                break;
        }
    }
}
