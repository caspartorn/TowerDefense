using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log(" More than one build manager in scene");
            return;
        }
        instance = this;
        
    }

    public GameObject standardTurretPrefab;
    public GameObject TacShooterPrefab;

    private GameObject turretToBuild;
    public GameObject GetTurretToBuild()
    { 
        return turretToBuild;


    }

    

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    
}
