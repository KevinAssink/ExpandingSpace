using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 3;
    public int curHealth = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }
   
    public void TakeDamage (int amount)
    {
        curHealth -= amount;
        Debug.Log("Hit!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
