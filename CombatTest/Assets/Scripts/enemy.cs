using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth= maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth-=damage;
        //parte de animcaion del enemigo

    }
    void Die(){
        Debug.Log("Enemy died");
    }
    //Animcion de muerte del enemigo
   
}
