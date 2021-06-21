using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setter : MonoBehaviour
{
    [SerializeField] Image[] foods = new Image[9];
    [SerializeField] Image[] foods_image = new Image[9];

    int[] setterFoods = new int[9];

    public void SetSetter(int batNum, int food, Sprite image)
    {
        setterFoods[batNum] = food;
        foods[batNum].sprite = image;
        foods_image[batNum].sprite = image;

        foods[batNum].gameObject.GetComponent<FoodsMovement>().GetSetFood = food;
    }
}
