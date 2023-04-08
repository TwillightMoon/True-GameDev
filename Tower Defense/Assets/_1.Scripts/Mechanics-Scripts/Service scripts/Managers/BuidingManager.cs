using UnityEngine;
using ConfigClasses.BuildingConfig;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private WalletScript walletScript;
    [SerializeField] private Transform parentObjForBuildings;

    public void Build(TacticalPoint placeForBuild, Building buildPrefab)
    {
        int buildingCost = buildPrefab.buildingsConfig.levelCost;

        if (CheckBalance(buildingCost))
        {
            walletScript.SubFromCurrentBalance(buildingCost);
            placeForBuild.SetBuilding(Instantiate(buildPrefab, parentObjForBuildings));
        }
        else
        {
            Debug.Log("Недостаточно средсв!");
        }
    }

    public void UpgradeTower(TacticalPoint placeForBuild)
    {
        BuildingsConfig buildingConfig = placeForBuild.GetBuilding().GetNextLevel();
        if (buildingConfig)
        {
            int buildingUpgradeCost = buildingConfig.levelCost;

            if (CheckBalance(buildingUpgradeCost))
            {
                placeForBuild.GetBuilding().SetNextLevel();
                walletScript.SubFromCurrentBalance(buildingUpgradeCost);
            }
            else
            {
                Debug.Log("Недостаточно средсв!");
            }
        }
    }

    public void SellBuild(TacticalPoint placeForBuild)
    {
        BuildingsConfig buildingConfig = placeForBuild.GetBuilding().buildingsConfig;
        int buildingSellCost = buildingConfig.sellCost;

        walletScript.AddToCurrentBalace(buildingSellCost);
        placeForBuild.DescructBuilding();
    }

    private bool CheckBalance(int buildingCost)
    {
        int currentBalance = walletScript.currentBalance;

        return currentBalance >= buildingCost;
    }
}
