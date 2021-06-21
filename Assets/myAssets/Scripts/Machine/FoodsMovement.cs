using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodsMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 _startPos;
    [SerializeField] FOODS food = FOODS.TOMATO;

    int foodNum = 0;

    private void Start()
    {
        foodNum = (int)food;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPos = transform.position;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _startPos;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public int GetSetFood
    {
        get { return foodNum; }
        set { foodNum = value;
        food = (FOODS)Enum.ToObject(typeof(FOODS), value);
        }
    }
}
