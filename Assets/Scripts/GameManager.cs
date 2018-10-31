using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    [Header("PlayerInfo")]

    //操作キャラ
    public GameObject Player;

    //最大HP
    public int PlayerMaxHP = 100;

    //現在の体力
    public int PlayerHP;

    //ニュートラルポジション
    public Transform Neutral;

    //爆発のパーティクル
    public GameObject Explosion;

    [Header("CollisionObjectsInfo")]

    //落ちてくる障害物のコレクション
    public GameObject[] CollisionObj;

    //落ちてくる障害物はこのリストの格納される
    public List<GameObject> ObjectsLs = new List<GameObject>();

    //生成オブジェクトのインスタンス
    public Spawner spawer;

    //エフェクトを格納するコレクション
    public List<GameObject> Effects = new List<GameObject>();


    //ゲームに出てくるUI
    [Header("UI-Info")]

    public GameObject GamePlayUI;
    public GameObject GameOverUI;

    [Header("Time")]
    public StopWatch stopwatch;
    public Text Min;
    public Text Sec;
    public Text Decimal;

    void Start()
    {
        //ゲームを始める
        NewGame();
    }

    void Update()
    {
        //HP0でゲームオーバー
        GameOver();
    }

    //新しくゲームを始める
    public void NewGame()
    {
        //UIの更新
        ShowUI(GamePlayUI);

        //操作キャラが見えるようにする
        Player.SetActive(true);

        //ニュートラルポジションに配置
        Player.transform.position = Neutral.position;
        Player.transform.rotation = Neutral.rotation;

        //既にあるエフェクトを削除
        DeleteEffects();

        //生成開始
        spawer.IsObjectSpawnring = true;

        //時間をリセット
        stopwatch.ResetTime();

        //最大HPで開始
        PlayerHP = PlayerMaxHP;
    }

    //ゲームオーバーの時に呼びだす
    public void GameOver()
    {
        //0になったらゲーム終了
        if (PlayerHP <= 0)
        {
            //敵オブジェクトを全部削除
            spawer.DeleteAllObjects();

            //生成停止
            spawer.IsObjectSpawnring = false;

            //爆発してロボット削除
            if (Player.activeSelf == true)
            {
                //プレイヤーが死んだ場所
                var deadPlace = Player.transform;

                //爆発を生成
                if (Explosion != null)
                {
                    var explosion = Instantiate(Explosion, deadPlace.position, deadPlace.rotation);
                    Effects.Add(explosion);
                }
            }

            //エフェクトは少し待ってから全削除
            StartCoroutine(DestroyEffect());

            Player.SetActive(false);

            //スコア時間を表示
            Decimal.text = stopwatch.Decimal.text;
            Min.text = stopwatch.Min.text;
            Sec.text = stopwatch.Sec.text;
            ShowUI(GameOverUI);
        }
    }
    
    //任意のUIを表示させる
    public void ShowUI(GameObject nowUI)
    {
        GameObject[] allUI = { GamePlayUI, GameOverUI };
        foreach(GameObject ui in allUI)
        {
            ui.SetActive(false);
        }
　　　　nowUI.SetActive(true);
    }
    
    //エフェクト削除のコルーチン
    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(2.0f);
        DeleteEffects();
    }

    //エフェクトを削除
    public void DeleteEffects()
    {
        foreach(GameObject effect in Effects)
        {
            Destroy(effect);
        }
        Effects.Clear();
    }
}
