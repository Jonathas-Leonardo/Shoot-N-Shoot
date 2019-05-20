using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spaceship {

public int live;
public int heart;
public string spaceship_name;
public int speed;
public int defense;
public int power;
public float handling;

public Spaceship(){
    live=1;
    heart=1;
    spaceship_name="vish";
    speed = 1;
    defense=1;
    power=1;
    handling=1;
}

}
