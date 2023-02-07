using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
  
    // Update is called once per frame
    void Update()
    {
        //Seleccionar la tecla de ataque
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    //Funcion de ataque
    void Attack()
    {
        //Animacion del ataque
        // ------------
        //como me gusta Liz
        //Detect enemy

        //OverlapArea - Genera un rea para delimitar arma
       Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit"+enemy.name);
        }
    }
    //visualizar area de ataque
    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        
    }
}
