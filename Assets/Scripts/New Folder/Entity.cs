using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    protected float _life;
    public float MaxLife;
    public float MinLife;
   
    public virtual void TakeDamage(float damage)
    {
        _life -= damage;
        if (_life <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void Update()
    {
        
    }


    /* public virtual void NameText()
     {
         string name = " ";

         name.LastIndexOf("");
         name = name.Insert(0, "hola ");
         name.Trim();
         string FirstL = name.Substring(0, 1).ToUpper();
         string NameFix = name.Substring(1).ToLower();
         name = FirstL + NameFix;
     }

     */
}
