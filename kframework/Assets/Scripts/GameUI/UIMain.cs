﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMain : UIBase {

    public GameObject RoundPanel;
    public GameObject BigButton;

    protected override void onShow()
    {
    }

    protected override void Awake()
    {
        AddTriggerListener(RoundPanel.gameObject, EventTriggerType.BeginDrag, OnBeginDragRound);

        var buttones = BigButton.GetComponentsInChildren<Button>();
        foreach (var item in buttones)
        {
            item.onClick.AddListener(() => OnClickBigStar(item.gameObject));
        }
    }

    protected override void Update()
    {
    }

    public void OnEndDragRound(PointerEventData eventData)
    {

    }

    public void OnDragRound(PointerEventData eventData)
    {

    }

    public void OnBeginDragRound(BaseEventData eventData)
    {
        if (eventData is PointerEventData)
        {
            Debug.LogError("pppppppppppp");
        }
        else
        {
            Debug.LogError("rrrrrrrrrrrrr");
        }
    }

    public void OnClickBigStar(GameObject obj)
    {
    }

    public void ToTransparent(float during)
    {
    }
}
