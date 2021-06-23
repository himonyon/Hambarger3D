using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setter : MonoBehaviour
{
    //セッターのバット
    [SerializeField] Image[] foods = new Image[9];
    [SerializeField] Image[] foods_image = new Image[9];
    [SerializeField] Image[] sauces = new Image[6];
    [SerializeField] Image[] sauces_image = new Image[6];

    //セッターの情報の保存
    int[] setterFoods = new int[9];
    int[] setterSauces = new int[6];

    //パンとパティ
    [SerializeField] Sprite s_patty, s_vans;
    [SerializeField] Image vans, patty;
    [SerializeField] Image vans_image, patty_image;

    private void Start()
    {
        vans.sprite = s_vans;
        patty.sprite = s_patty;
        vans_image.sprite = s_vans;
        patty_image.sprite = s_patty;

        vans.gameObject.GetComponent<FoodsMovement>().GetSetFood = (int)FOODS.VANS;
        patty.gameObject.GetComponent<FoodsMovement>().GetSetFood = (int)FOODS.PATTY;
    }

    public void SetSetter(int batNum, int food, Sprite image, bool isSauce)
    {
        if (isSauce)
        {
            setterSauces[batNum] = food;
            sauces[batNum].sprite = image;
            sauces_image[batNum].sprite = image;

            sauces[batNum].gameObject.GetComponent<FoodsMovement>().GetSetFood = food;
            return;
        }

        setterFoods[batNum] = food;
        foods[batNum].sprite = image;
        foods_image[batNum].sprite = image;

        foods[batNum].gameObject.GetComponent<FoodsMovement>().GetSetFood = food;
    }
}
