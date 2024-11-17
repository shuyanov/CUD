using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;

public enum FieldType
{
    SELF_HAND,
    SELF_FIELD,
    ENEMY_HAND,
    ENEMY_FIELD
}

public class drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public FieldType Type;

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.SELF_FIELD)
        {
            return;
        }


        CardMovementSrc selectCard = eventData.pointerDrag.GetComponent<CardMovementSrc>();
        if (selectCard)
        {
            selectCard.DefaultParent = transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || Type == FieldType.ENEMY_FIELD || Type == FieldType.ENEMY_HAND)
        {
            return;
        }

        CardMovementSrc selectCard = eventData.pointerDrag.GetComponent<CardMovementSrc>();

        if (selectCard)
        {
            selectCard.DefaultTempCardPatent = transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        CardMovementSrc selectCard = eventData.pointerDrag.GetComponent<CardMovementSrc>();

        if (selectCard && selectCard.DefaultTempCardPatent == transform)
        {
            selectCard.DefaultTempCardPatent = selectCard.DefaultParent;
        }
    }
}
