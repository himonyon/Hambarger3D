using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Refrigerator : MonoBehaviour
{
    [SerializeField] GameObject inventory_foods, inventory_sauces, refrigerator_foods, refrigerator_sauces;

    [SerializeField] Image[] foods;
    [SerializeField] Image[] foods_image;
    [SerializeField] Image[] sauces;
    [SerializeField] Image[] sauces_image;

    [SerializeField] Sprite tomato, lettuce, cabbage, cheese, egg, pickles, avocado,
        ketchup, mustard, mayonnaise, cutletSauce, tartar, aurora;

    bool isSauce = false;

    private void Start()
    {
        SetRefrigerator();
    }

    public void SetRefrigerator()
    {
        inventory_sauces.SetActive(false);
        refrigerator_sauces.SetActive(false);
        inventory_foods.SetActive(true);
        refrigerator_foods.SetActive(true);

        for(int i = 0; i < foods.Length; i++)
        {
            foods[i].sprite = GetFoodImage((int)FOODS.TOMATO + i);
            foods_image[i].sprite = GetFoodImage((int)FOODS.TOMATO + i);
            foods[i].GetComponent<FoodsMovement>().GetSetFood = (int)FOODS.TOMATO + i;
        }

        for (int i = 0; i < sauces.Length; i++)
        {
            sauces[i].sprite = GetSauceImage((int)SAUCES.KETCHUP + i);
            sauces_image[i].sprite = GetSauceImage((int)SAUCES.KETCHUP + i);
            sauces[i].GetComponent<FoodsMovement>().GetSetFood = (int)SAUCES.KETCHUP + i;
        }
    }

    public void ChangeCategory()
    {
        isSauce = !isSauce ? true : false;
        if (isSauce)
        {
            inventory_sauces.SetActive(true);
            refrigerator_sauces.SetActive(true);
            inventory_foods.SetActive(false);
            refrigerator_foods.SetActive(false);
        }
        else
        {
            inventory_sauces.SetActive(false);
            refrigerator_sauces.SetActive(false);
            inventory_foods.SetActive(true);
            refrigerator_foods.SetActive(true);
        }
    }

    //セッターに送る情報
    public Sprite GetFoodImage(int sauceNum)
    {
        switch (sauceNum)
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

    public Sprite GetSauceImage(int foodNum)
    {
        switch (foodNum)
        {
            case (int)SAUCES.KETCHUP:
                return ketchup;
            case (int)SAUCES.MUSTARD:
                return mustard;
            case (int)SAUCES.MAYONNAISE:
                return mayonnaise;
            case (int)SAUCES.TARTAR:
                return tartar;
            case (int)SAUCES.CUTLETSAUCE:
                return cutletSauce;
            case (int)SAUCES.AURORA:
                return aurora;
            default:
                return tomato;
        }
    }

    public bool GetIsSauce
    {
        get { return isSauce; }
    }
}
