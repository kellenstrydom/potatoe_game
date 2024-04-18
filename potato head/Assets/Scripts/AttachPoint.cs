using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttachPoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PartManager PartManager;
    public Transform potato;
    
    private MeshRenderer mesh;

    private bool isSelected = false;

    private void Start()
    {
        PartManager = GameObject.FindWithTag("GameController").GetComponent<PartManager>();
        if (potato == null)
            potato = GameObject.FindWithTag("Potato").transform;
        mesh = gameObject.GetComponent<MeshRenderer>();
        
        transform.LookAt(potato);
    }

    public void PartPlaced()
    {
        mesh.enabled = false;
        this.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PartManager.SetPoint(transform);
        mesh.material.SetColor("_Color",Color.green);

        isSelected = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSelected) return;
        mesh.material.SetColor("_Color",Color.cyan);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected) return;
        Deselect();
    }

    public void Deselect()
    {
        mesh.material.SetColor("_Color",Color.grey);
        isSelected = false;
    }
}
