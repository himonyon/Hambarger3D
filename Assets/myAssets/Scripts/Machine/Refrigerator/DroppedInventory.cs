using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DroppedInventory : MonoBehaviour, IDropHandler
{
    [SerializeField] Setter setter;
    [SerializeField] Refrigerator refrigerator;

    [SerializeField] int batNum = 0;

    public void OnDrop(PointerEventData eventData)
    {

        int food = eventData.pointerDrag.GetComponent<FoodsMovement>().GetSetFood;

        Sprite foodSprite = refrigerator.GetFoodImage(food);
        
        gameObject.GetComponent<Image>().sprite = foodSprite;

        setter.SetSetter(batNum, food, foodSprite);
    }
}