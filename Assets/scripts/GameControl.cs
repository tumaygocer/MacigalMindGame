using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{


    int firstchoicevalue;
    GameObject ClickedObject;
    public Sprite DefaultSprite;
    GameObject SelectedButton;
    public AudioSource[] Sounds;
    public GameObject[] Buttons;
    



    void Start()
    {
        firstchoicevalue = 0;
    }

    public void SelectObject(GameObject Objem)
    {
        Sounds[1].Play();
        ClickedObject = Objem;
        ClickedObject.GetComponent<Image>().sprite = ClickedObject.GetComponentInChildren<SpriteRenderer>().sprite;
        ClickedObject.GetComponent<Image>().raycastTarget = false;
    }

    public void Statusofbuttons(bool durum)
    {
        foreach (var item in Buttons)
        {
            if (item != null)
            {
                item.GetComponent<Image>().raycastTarget = durum;
            }
            
        }
    }

    public void ButtonClicked(int value)
    {
        Control(value);
    }

    void Control(int SelectedValue)
    {
        if (firstchoicevalue == 0)
        {
            firstchoicevalue = SelectedValue;
            SelectedButton = ClickedObject;
        }
        else
        {
            StartCoroutine(StandbyTime(SelectedValue));

        }
    }
    IEnumerator StandbyTime(int SelectedValue)
    {
        Statusofbuttons(false);
        yield return new WaitForSeconds(1);

        if (firstchoicevalue == SelectedValue)
        {
            Sounds[2].Play();
            Destroy(SelectedButton.gameObject);
            Destroy(ClickedObject.gameObject);           
            Debug.Log("e�le�ti");
            firstchoicevalue = 0;
            SelectedButton = null;
            Statusofbuttons(true);
        }
        else
        {
            Sounds[3].Play();
            SelectedButton.GetComponent<Image>().sprite = DefaultSprite;
            ClickedObject.GetComponent<Image>().sprite = DefaultSprite;
            Debug.Log("e�le�medi");
            firstchoicevalue = 0;
            SelectedButton = null;
            Statusofbuttons(true);
        }
    }
}
