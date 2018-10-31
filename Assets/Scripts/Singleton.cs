using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このクラスは他のオブジェクトがひとつの共有オブジェクトに参照することを実現します。
//GameManagerとInputクラスがこれを継承

public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{

    //このクラスの一つの共有インスタンス
    private static T _instance;

    //アクセサー　これが初めて呼ばれたときだけ_instanceを初期化する。
    //見つからなかったらエラーを吐く

    public static T instance
    {
        get
        {
            //_instanceを設定していない場合
            if (_instance == null)
            {
                //オブジェクトを探す
                _instance = FindObjectOfType<T>();

                //見つけられなかったらエラーを吐く
                if (_instance == null)
                {
                    Debug.LogError("Can't find" + typeof(T) + "!");
                }
            }

            return _instance;
        }
    }

}
