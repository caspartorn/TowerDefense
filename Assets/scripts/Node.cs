using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hovercolor = Color.blue;
    public Vector3 positionOffset;

    private GameObject turret;


    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter ()
    {
        rend.material.color = hovercolor;

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (turret != null ) 
        {
            Debug.Log("Kan inte placera h�r.");
            return;
        }


        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild,transform.position + positionOffset, transform.rotation);

    }
}
