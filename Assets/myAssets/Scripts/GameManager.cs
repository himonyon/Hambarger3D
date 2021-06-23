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
    VANS = 98,
    PATTY,
}

enum SAUCES
{
    KETCHUP = 100,
    MUSTARD,
    MAYONNAISE,
    TARTAR,
    CUTLETSAUCE,
    AURORA,
    MAX,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
}
