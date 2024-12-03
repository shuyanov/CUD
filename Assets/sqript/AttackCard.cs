using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardInfoScr card = eventData.pointerDrag.GetComponent<CardInfoScr>();

        if (card && card.SelfCard.CanAttack && transform.parent == GetComponent<CardMovementSrc>().GameManager.EnemyField)
        {
            card.SelfCard.ChangeAttackState(false);
            GetComponent<CardMovementSrc>().GameManager.CardsFight(card, GetComponent<CardInfoScr>());

            if (card.IsPlayer)
                card.DeHighlightCard();
        }
    }
}
