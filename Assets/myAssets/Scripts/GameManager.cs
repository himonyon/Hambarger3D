using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum MACHINE
{
    TEPPAN,
    SETTER,
    REFRIGERATOR,
    MAX,
}

enum FOODS
{
    TOMATO,
    LETTUCE,
    CABBAGE,
    CHEESE,
    EGG,
    PICKLES,
    AVOCADO,
    MAX,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
}
