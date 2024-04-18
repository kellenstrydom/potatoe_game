using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartManager : MonoBehaviour
{
    public Transform selectedPoint;
    public List<GameObject> parts;
    public Transform potato;
    public GameObject panel;

    private bool isPointSelected = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PlacePart(0);
        if (Input.GetKeyDown(KeyCode.L))
            PlacePart(1);
        if (Input.GetKeyDown(KeyCode.A))
            PlacePart(2);
        if (Input.GetKeyDown(KeyCode.E))
            PlacePart(3);
    }

    public void SetPoint(Transform point)
    { 
        CancelSelection();
        
        selectedPoint = point;
        isPointSelected = true;
        panel.SetActive(true);
    }

    public void CancelSelection()
    {
        isPointSelected = false;
        if (selectedPoint == null) return;
        
        selectedPoint.GetComponent<AttachPoint>().Deselect();
        panel.SetActive(false);
    }

    public void PlacePart(int index)
    {
        Instantiate(parts[index], selectedPoint.position, selectedPoint.rotation, selectedPoint);
        selectedPoint.GetComponent<AttachPoint>().PartPlaced();
        selectedPoint = null;
        isPointSelected = false;
        panel.SetActive(false);
    }
    
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
