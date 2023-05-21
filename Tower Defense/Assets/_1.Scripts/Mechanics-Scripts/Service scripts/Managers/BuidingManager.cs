using Buildings;
using Buildings.Modules;
using ConfigClasses.ConfigBuildings;
using UnityEngine;

namespace Managers
{
    /** Менеджер, отвечающий за взаимодействие с постройками. 
     * Эти взаимодейтсвия включают в себя строительство (покупку), улучшение.
     */

    public class BuildingManager : Singleton<BuildingManager>
    {
        [SerializeField] private Transform parentObjForBuildings; /**< Transform variable. Родительский объект для всех новых построек. */

        /** Метод для строительства (создания) новой постройки.
         * @param TacticalPoint placeForBuild - позиция для новой построки.
         * @param Building buildPrefab - шаблон новой постройки.
         */

        public void Build(TacticalPoint placeForBuild, Building buildPrefab)
        {
            BuildingCharacteristics buildingCharacteristic = buildPrefab.GetComponentInChildren<BuildingCharacteristics>();
            if (buildingCharacteristic == null)
                BuildWithoutCost(placeForBuild, buildPrefab);
            else
                BuildWithCost(placeForBuild, buildPrefab, buildingCharacteristic.GetCurrentLevel().levelCost);
        }

        private void BuildWithoutCost(TacticalPoint placeForBuild, Building buildPrefab)
        {
            placeForBuild.SetBuilding(buildPrefab);
        }
        private void BuildWithCost(TacticalPoint placeForBuild, Building buildPrefab, int buildingCost)
        {
            if (CheckBalance(buildingCost))
            {
                WalletScript.instance.SubFromCurrentBalance(buildingCost);
                placeForBuild.SetBuilding(buildPrefab);
            }
            else
                Debug.Log("Недостаточно средсв!");
        }

        /** Метод улучшения постройки.
         * @param TacticalPoint placeForBuild - Позиция, на которой распологается башня.
         */
        public void UpgradeTower(TacticalPoint placeForBuild)
        {
            BuildingCharacteristics buildingCharacteristic = placeForBuild.GetBuilding().GetComponentInChildren<BuildingCharacteristics>();
            if (buildingCharacteristic == null || buildingCharacteristic.GetNextLevel() == null) 
                return;

            int buildingUpgradeCost = buildingCharacteristic.GetNextLevel().levelCost;

            if (CheckBalance(buildingUpgradeCost))
            {
                buildingCharacteristic.SetNextLevel();
                WalletScript.instance.SubFromCurrentBalance(buildingUpgradeCost);
            }
            else
            {
                Debug.Log("Недостаточно средсв!");
            }
        }

        /** Метод продажи постройки.
         * @param TacticalPoint placeForBuild - Позиция, на которой распологается башня.
         */
        public void SellBuild(TacticalPoint placeForBuild)
        {
            BuildingConfig buildingConfig = placeForBuild.GetBuilding().buildingsConfig;
            int buildingSellCost = buildingConfig.sellCost;

            WalletScript.instance.AddToCurrentBalace(buildingSellCost);
            placeForBuild.DescructBuilding();
        }
        /** Метод проверки необходимой суммы в кошельке.
         * @param int buildingCost - сумма, которую необходимо вычесть.
         */
        private bool CheckBalance(int buildingCost)
        {
            int currentBalance = WalletScript.instance.currentBalance;

            return currentBalance >= buildingCost;
        }
    }
}