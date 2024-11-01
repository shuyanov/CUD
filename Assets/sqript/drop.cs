using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;

public class drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardSrc selectCard = eventData.pointerDrag.GetComponent<CardSrc>();
        if (selectCard)
        {
            selectCard.DefaultParent = transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        CardSrc selectCard = eventData.pointerDrag.GetComponent<CardSrc>();

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

        CardSrc selectCard = eventData.pointerDrag.GetComponent<CardSrc>();

        if (selectCard && selectCard.DefaultTempCardPatent == transform)
        {
            selectCard.DefaultTempCardPatent = selectCard.DefaultParent;
        }
    }
}
