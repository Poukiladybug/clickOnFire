using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Manager manager;
    public bool mouseOver;
    public bool isBlue = false;
    public float theTime;
    public float anotherTimer;

    public void Start()
    {
        anotherTimer = Random.Range(3f, 5f);

    }
    private void OnMouseOver()
    {
        mouseOver = true;
        
    }

    private void OnMouseExit()
    {
        mouseOver = false;
       
    }
    public void Update()
    {
        anotherTimer -= Time.deltaTime;
        if (Input.GetMouseButtonUp(0) && mouseOver)
        {
            manager.DestroyGameObject(gameObject);
        }
        if (anotherTimer <= 0f)
        {
            manager.TimeDestroyGameObject(gameObject);
            anotherTimer = Random.Range(3f, 5f);
        }
    }
}
