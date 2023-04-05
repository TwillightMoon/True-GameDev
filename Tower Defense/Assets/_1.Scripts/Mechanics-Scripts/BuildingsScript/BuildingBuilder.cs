using UnityEngine;

public class BuildingBuilder : MonoBehaviour
{
    [SerializeField] private WalletScript walletScript;
    [SerializeField] private Transform parentObjForBuildings;

    public void Build(TacticalPoint placeForBuild, Buildings buildPrefab)
    {
        Debug.Log(buildPrefab.buildingsConfig);
        uint buildingCost = buildPrefab.buildingsConfig.levelCost;

        if (CheckBalance(buildingCost))
        {
            walletScript.SubFromCurrentBalance((int)buildingCost);
            placeForBuild.SetBuilding(Instantiate(buildPrefab, parentObjForBuildings));
        }
        else
        {
            Debug.Log("Недостаточно средсв!");
        }
    }

    private bool CheckBalance(uint buildingCost)
    {
        uint currentBalance = (uint)walletScript.currentBalance;

        return currentBalance >= buildingCost;
    }
}
