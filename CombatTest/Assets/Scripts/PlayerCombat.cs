using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour{
    
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask manaLayers;
    public int attackDamage = 40;
  
    // Update is called once per frame
    void Update(){
        //Seleccionar la tecla de ataque
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
        
    }
    //Funcion de ataque
    void Attack(){
        //Animacion del ataque
        // ------------
        //Detect enemy

        //OverlapArea - Genera un rea para delimitar arma
        Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            Debug.Log("We hit"+enemy.name);
        }
        
    }

    //visualizar area de ataque
    void OnDrawGizmosSelected() {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Mana"){
            Debug.Log("Mana");
            Destroy(other);
        }
    }
}
