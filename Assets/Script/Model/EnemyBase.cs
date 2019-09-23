using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBase {

public int live;
public int heart;
public string enemy_name;
public int speed;
public int defense;
public int power;
public float handling;

public bool isShot;
public int ammo;

public EnemyBase(){
    live=1;
    heart=1;
    enemy_name="default";
    speed = 1;
    defense=1;
    power=1;
    handling=1;
    ammo=1;
}

}
