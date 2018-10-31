using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollosionObj : MonoBehaviour {

    public GameObject dustructionPrefab;

    public int HitPoint = 10;

    void Update()
    {
        //落ちたら消去
        DeleteObject();
    }

    //衝突したらhitエフェクトを生成
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //障害物は消滅
            Destroy(gameObject);

            //HPが減少
            GameManager.instance.PlayerHP -= HitPoint;


            if(dustructionPrefab != null)
            {
                //エフェクトを生成してコレクションに追加する
                var destruction = Instantiate(dustructionPrefab, transform.position, Quaternion.identity);
                GameManager.instance.Effects.Add(destruction);
            }
        }
    }

    //一定まで落ちたら消去
    void DeleteObject()
    {
        if(transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }
}
