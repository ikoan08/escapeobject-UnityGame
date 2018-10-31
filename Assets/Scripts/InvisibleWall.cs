using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour {

    //見えない壁
    public Collider Wall;


    //一方通行の処理
    public void OnTriggerEnter(Collider other)
    {
        //プレイヤーは通れない
        if (other.gameObject.tag != "Player")
        {
            Physics.IgnoreCollision(Wall, other);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(Wall, other, false);
    }
}
