using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour

{

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    
    public void PurchaseStandardTurret()
    {
        Debug.Log("Purchase standard turret");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseTackshooter()
    {
        Debug.Log("Purchase Tackshooter ");
        buildManager.SetTurretToBuild(buildManager.TacShooterPrefab);
    }
}
