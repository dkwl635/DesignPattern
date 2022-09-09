using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBase
{
    public eTEAM atkType;
    public int damage;
    public Vector3 dir;

    public virtual void Open(eTEAM atkType, int damage , Vector3 pos , Vector3 dir)
    {
        base.Open();
        this.atkType = atkType;
        this.damage = damage;
        transform.position = pos;
        this.dir = dir;

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        transform.position += dir * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Actor owner = other.gameObject.GetComponent<Actor>();
        if (Actor.IsFife(owner) == false)
            return;

        if (owner.data.team != atkType)
            return;

        owner.data.AddHp(-damage);
        Close();
    }




}
