using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HamburgerCreate : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject food_prefab;

    [SerializeField] Sprite vans_top;

    [SerializeField] bool isHamburger1;

    List<int> hamburger1 = new List<int>(), hamburger2 = new List<int>();

    int currentPosition1, currentPosition2;
    bool isComplete = false;

    public void OnDrop(PointerEventData eventData)
    {
        int food_num = eventData.pointerDrag.GetComponent<FoodsMovement>().GetSetFood;

        //初手がバンズ以外もしくは完成中は乗せない
        if (isHamburger1)
        {
            if(hamburger1.Count == 0 && food_num != (int)FOODS.VANS || isComplete)
            {
                return;
            }
        }
        else
        {
            if(hamburger2.Count == 0 && food_num != (int)FOODS.VANS || isComplete)
            {
                return;
            }
        }

        //画像の作成とハンバーガーの情報の更新
        GameObject food = Instantiate(food_prefab, transform);
        food.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;

        if (isHamburger1)
        {
            if(hamburger1.Count != 0 )
            {
                food.transform.localPosition = new Vector3(0, currentPosition1 + 10 , 0);
                currentPosition1 += 10;
            }
            else
            {
                food.transform.localPosition = Vector3.zero;
                currentPosition1 = 20;
            }

            hamburger1.Add(food_num);  //ハンバーガーの情報の保存
        }
        else
        {
            if (hamburger2.Count != 0)
            {
                food.transform.localPosition = new Vector3( 0, currentPosition2 + 10, 0);
                currentPosition2 += 10;
            }
            else
            {
                food.transform.localPosition = Vector3.zero;
                currentPosition2 = 20;
            }

            hamburger2.Add(food_num);
        }
    }

    //完成時
    public void CompleteHamburger()
    {
        //上バンスを載せる
        isComplete = true;

        GameObject food = Instantiate(food_prefab, transform);
        food.GetComponent<Image>().sprite = vans_top;

        if (isHamburger1)
        {
            food.transform.localPosition = new Vector3(0, currentPosition1 + 15, 0);
            hamburger1.Add((int)FOODS.VANS);
        }
        else
        {
            food.transform.localPosition = new Vector3(0, currentPosition2 + 15, 0);
            hamburger2.Add((int)FOODS.VANS);
        }

        //初期化
        StartCoroutine("ResetHamburger", 3.0f);
    }

    private IEnumerator ResetHamburger(float time)
    {
        yield return new WaitForSeconds(time);

        foreach (RectTransform child in transform)
        {
            Destroy(child.gameObject);
        }

        if (isHamburger1)
        {
            hamburger1.Clear();
            hamburger1 = new List<int>();
            currentPosition1 = 0;
        }
        else
        {
            hamburger2.Clear();
            hamburger2 = new List<int>();
            currentPosition2 = 0;
        }

        isComplete = false;
    }
}
