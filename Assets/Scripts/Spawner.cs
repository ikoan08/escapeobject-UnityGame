using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //プレハブ
    public GameObject EnemyObj;

    //生成するかどうか
    public bool IsObjectSpawnring;

    //何秒ごとに生成するか
    public float nextSpawnTime = 3;

    //生成するｘの範囲
    public float borderWall;


    void Start()
    {
        //生成する範囲を代入
        borderWall = GameObject.Find("RightWall").transform.position.x - 0.35f;
        //生成を開始
        StartCoroutine(CreateObject());
    }


    IEnumerator CreateObject()
    {
        //無限ループ
        while (true)
        {
            yield return new WaitForSeconds(nextSpawnTime);
            CreateNewObject();
        }
    }

    void CreateNewObject()
    {
        //偽なら生成を止める
        if (IsObjectSpawnring == false)
        {
            return;
        }

        //壁の範囲内でランダムに生成
        var CreatePosition = this.transform.position;
        CreatePosition.x = Random.Range(-borderWall, borderWall);

        var objs = Instantiate(EnemyObj, CreatePosition, Quaternion.identity);
        GameManager.instance.ObjectsLs.Add(objs);
    }

    //シーン上の障害オブジェクトを全部削除
    public void DeleteAllObjects()
    {
        foreach (GameObject obj in GameManager.instance.ObjectsLs)
        {
            Destroy(obj);
        }
        GameManager.instance.ObjectsLs.Clear();
    }


}
