using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Refrigerator : MonoBehaviour
{

    [SerializeField] Sprite tomato, lettuce, cabbage, cheese, egg, pickles, avocado;

    public Sprite GetFoodImage(int foodNum)
    {
        switch (foodNum)
        {
            case (int)FOODS.TOMATO:
                return tomato;
            case (int)FOODS.LETTUCE:
                return lettuce;
            case (int)FOODS.CABBAGE:
                return cabbage;
            case (int)FOODS.CHEESE:
                return cheese;
            case (int)FOODS.EGG:
                return egg;
            case (int)FOODS.PICKLES:
                return pickles;
            case (int)FOODS.AVOCADO:
                return avocado;
            default:
                return tomato;
        }
    }
}
