using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Manager manager;
    public bool mouseOver;
    public bool isBlue = false;

    private void OnMouseOver()
    {
        mouseOver = true;
        
    }

    private void OnMouseExit()
    {
        mouseOver = false;
       
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && mouseOver)
        {

            manager.DestroyGameObject(gameObject);


        }
    }
}
