using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {

    public Text HP;

    void Update()
    {
        HP.text = GameManager.instance.PlayerHP.ToString();
    }
}
