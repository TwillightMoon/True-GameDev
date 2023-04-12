using UnityEngine;
using ConfigClasses.BuildingConfig;
using Buildings;

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

        /** Метод улучшения постройки.
         * @param TacticalPoint placeForBuild - Позиция, на которой распологается башня.
         */
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