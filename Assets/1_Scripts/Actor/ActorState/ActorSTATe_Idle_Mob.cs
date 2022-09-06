using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState_Idle_Mob : ActorState
{
   public ActorState_Idle_Mob(Actor actor) :base (actor , eACTOR_STATE.IDLE)
    {

    }

    public override void Update()
    {
        base.Update();
        if(m_owner.data.hp <= 0 )
        {
            m_owner.fsm.SetState(eACTOR_STATE.DIE);
            return;
        }

        if(m_owner.mover.isStop == true)
        {
            Tile curTile = m_owner.attack.GetCurTile();
           

            if (curTile == null || curTile.titleType == eTILE_TYPE.TARGET)
            {
                GamePlayLogic_Battle.Instance.playData.AddHp(-1); 
                m_owner.fsm.SetState(eACTOR_STATE.DIE);
                return;
            }
         
            Tile targetTile = GamePlayLogic_Battle.Instance.tileMap.GetNearTile(eTILE_TYPE.TARGET, curTile, m_owner.attack.preTile);
            if(targetTile  != null)
            {
                m_owner.attack.preTile = curTile;
                m_owner.mover.Move(targetTile.transform.position);
                return;
            }
          
            Tile moveTile = GamePlayLogic_Battle.Instance.tileMap.GetNearTile(eTILE_TYPE.MOVEABLE, curTile, m_owner.attack.preTile);
            if(moveTile != null)
            {
                m_owner.attack.preTile = curTile;
                m_owner.mover.Move(moveTile.transform.position);
                return;
            }


         
            m_owner.attack.preTile = null;
        }
    }
}
