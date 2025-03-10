﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemName;
    public Text itemInfo;

    private RectTransform rectTransform;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnEnable() 
    {
        GetMousePosition();    
    }
    public void SetupTooltip(ItemData_SO item)
    {
        itemName.text = item.ItemName;
        itemInfo.text = item.description;
    }

    public void Update() 
    {
        GetMousePosition();    
    }


    public void GetMousePosition()
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        float width = corners[3].x - corners[0].x;
        float height = corners[1].y - corners[0].y;

        Vector3 mousePos = Input.mousePosition;

        if (mousePos.y < height)
            rectTransform.position = mousePos + Vector3.up * height * 0.6f;
        else if (Screen.width - mousePos.x > width)
            rectTransform.position = mousePos + Vector3.right * width * 0.6f;
        else
            rectTransform.position = mousePos + Vector3.left * width * 0.6f;

    }
}
