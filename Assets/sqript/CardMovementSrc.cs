using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementSrc : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent, DefaultTempCardPatent;
    GameObject TempCardGo;
    public bool IsDraggable;

    void Awake()
    {
        MainCamera = Camera.allCameras[0];
        TempCardGo = GameObject.Find("TempCardGo");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);

        DefaultParent = DefaultTempCardPatent = transform.parent;
        IsDraggable = DefaultParent.GetComponent<drop>().Type == FieldType.SELF_HAND;

        if (!IsDraggable)
            return;

        TempCardGo.transform.SetParent(DefaultParent);
        TempCardGo.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!IsDraggable)
            return;

        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPos + offset;

        if (TempCardGo.transform.parent != DefaultTempCardPatent)
        {
            TempCardGo.transform.SetParent(DefaultTempCardPatent);
        }

        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (!IsDraggable)
            return;

        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        transform.SetSiblingIndex(TempCardGo.transform.GetSiblingIndex());
        TempCardGo.transform.SetParent(GameObject.Find("Canvas").transform);
        TempCardGo.transform.localPosition = new Vector3(1128, 0);

    }

    void CheckPosition()
    {
        int newIndex = DefaultTempCardPatent.childCount;

        for (int i = 0; i < DefaultTempCardPatent.childCount; i++)
        {
            if (transform.position.x < DefaultTempCardPatent.GetChild(i).position.x)
            {
                newIndex = i;
                if (TempCardGo.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }
                break;
            }
        }
        TempCardGo.transform.SetSiblingIndex(newIndex);
    }
}
