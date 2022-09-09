using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState_Play : BattleState
{
    public BattleState_Play(GamePlayLogic_Battle _logic) : base(_logic, eBATTLE_STATE.PLAY)
    {

    }

    public override void Update()
    {
        base.Update();

        if(m_logic.monsterSpawn.monsterMaxSpawnCount <= m_logic.monsterSpawn.monsterSpawnCount && ActorManager.Instance.GetCount(eTEAM.MONSTER) <=0)
        {
            m_logic.playData.SetBattleResult(eBATTLE_RESULT.SUCC);
            m_logic.fsm.SetState(eBATTLE_STATE.RESULT);
            return;
        }

        if (m_logic.playData.hp <= 0)
        {     
            m_logic.playData.SetBattleResult(eBATTLE_RESULT.FAILED);
            m_logic.fsm.SetState(eBATTLE_STATE.RESULT);
            return; 
        }

        if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()==false && Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction * 1000f, out hit))
            {
                Transform _colliderParent = hit.collider.transform.parent;
                if(_colliderParent != null)
                {
                    Tile _tile = _colliderParent.gameObject.GetComponent<Tile>();
                    if(_tile != null && _tile.titleType == eTILE_TYPE.SPAWN)
                    {
                        UISpawnDialog uISpawnDialog = UIManager.Instance.dialog.GetDlg<UISpawnDialog>("UI/UIBattle/UISpawnDialog") ;
                        uISpawnDialog.Open(_tile);
                    }
                }
            }


        }

        m_logic.monsterSpawn.Update();
        ActorManager.Instance.UpdateLogic();
    }

}
