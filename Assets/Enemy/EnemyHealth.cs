using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxhitPoints = 4;
    [SerializeField] int diffucultyRamp =1;
    int currentHitPoints = 0;
    
    Enemy enemy;

    void Start()
    {
        enemy   =   GetComponent<Enemy>();   
    }
    void OnEnable()
    {
        currentHitPoints = maxhitPoints;

    }

   void OnParticleCollision(GameObject other) 
   {
        var tower = other.GetComponentInParent<Tower>();
        if(tower  != null)
        {
            takeDamage(tower.damage);
        }    

   }
 
    public void takeDamage(int damage)
    {
        currentHitPoints -= damage;
        if (currentHitPoints <= 0)
        {
            maxhitPoints += diffucultyRamp;
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
