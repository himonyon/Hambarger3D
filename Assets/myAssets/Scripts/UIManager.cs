using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button actionButton;
    [SerializeField] GameObject setterPanel;
    [SerializeField] GameObject refrigeratorPanel;

    [SerializeField] PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActiveActionButton();
    }

    void ActiveActionButton()
    {
        if (player.CheckObj() != (int)MACHINE.MAX)
        {
            actionButton.interactable = true;
        }
        else
        {
            actionButton.interactable = false;
        }
    }

    public void PushActiveButtton()
    {
        switch (player.CheckObj())
        {
            case (int)MACHINE.TEPPAN:
                Debug.Log("TEPPAN");
                break;
            case (int)MACHINE.SETTER:
                setterPanel.SetActive(true);
                break;
            case (int)MACHINE.REFRIGERATOR:
                refrigeratorPanel.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void HidePanel()
    {
        setterPanel.SetActive(false);
        refrigeratorPanel.SetActive(false);
    }
}
