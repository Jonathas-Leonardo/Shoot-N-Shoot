using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spaceship {

public int live;
public int heart;
public string name;
public int speed;
public int defense;
public int power;
public float handling;

public Spaceship(){
    live=1;
    heart=1;
    name="vish";
    speed = 1;
    defense=1;
    power=1;
    handling=1;
}

}
