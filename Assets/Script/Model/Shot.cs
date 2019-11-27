using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public int speed;
    public int power;
    public int live;
    public string parentTag;
    public Player playerObj;
    public string colliderTag;

    public Shot () {
        speed = 1;
        power = 1;
        live = 1;
    }
}