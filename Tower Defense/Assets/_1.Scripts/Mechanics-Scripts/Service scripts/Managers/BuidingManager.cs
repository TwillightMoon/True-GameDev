using Buildings;
using Buildings.Modules;
using ConfigClasses.BuildingConfig;
using UnityEngine;

namespace Managers
{
    /** Менеджер, отвечающий за взаимодействие с постройками. 
     * Эти взаимодейтсвия включают в себя строительство (покупку), улучшение.
     */

    public class BuildingManager : MonoBehaviour
    {
        [SerializeField] private WalletScript walletScript; /**< WalletScript variable. Объект, содержащий текующий баланс игрока. */
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
            placeForBuild.SetBuilding(Instantiate(buildPrefab, parentObjForBuildings));
        }
        private void BuildWithCost(TacticalPoint placeForBuild, Building buildPrefab, int buildingCost)
        {
            if (CheckBalance(buildingCost))
            {
                walletScript.SubFromCurrentBalance(buildingCost);
                placeForBuild.SetBuilding(Instantiate(buildPrefab, parentObjForBuildings));
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
            if (buildingCharacteristic == null) return;

            int buildingUpgradeCost = buildingCharacteristic.GetNextLevel().levelCost;

            if (CheckBalance(buildingUpgradeCost))
            {
                buildingCharacteristic.SetNextLevel();
                walletScript.SubFromCurrentBalance(buildingUpgradeCost);
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
            BuildingsConfig buildingConfig = placeForBuild.GetBuilding().buildingsConfig;
            int buildingSellCost = buildingConfig.sellCost;

            walletScript.AddToCurrentBalace(buildingSellCost);
            placeForBuild.DescructBuilding();
        }
        /** Метод проверки необходимой суммы в кошельке.
         * @param int buildingCost - сумма, которую необходимо вычесть.
         */
        private bool CheckBalance(int buildingCost)
        {
            int currentBalance = walletScript.currentBalance;

            return currentBalance >= buildingCost;
        }
    }
}