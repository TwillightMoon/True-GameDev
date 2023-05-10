using ConfigClasses.ConfigBuildings;
using ModuleClass;
using System;
using UnityEngine;

namespace Buildings.Modules
{
    public class BuildingCharacteristics : Module
    {
        private Building _parent;

        [Header("Характеристика постройки на каждом уровне")]
        private int _currentLevelIndex = 0 /**< integer variable. Индекс текущего уровня постройки */;
        [SerializeField] private BuildingConfig[] _characteristicsOfLevels /**< integer[] variable. Массив уровней построки. */;


        private void Awake()
        {
            base.Init();
            SortLevels();

            _parent = ClassConverter<Building>.Convert(m_moduleParent);
            _parent.SetNewCharacteristics(_characteristicsOfLevels[0]);
        }

        private void OnEnable() => _parent.AddModule(this);
        private void OnDisable() => _parent.RemoveModule(this);

        /**
         * Метод получения возможного следующего уровня постройки.
         * @return Следующий доступный уровень или null.
         * @see SetNextLevel()
        */
        public BuildingConfig GetNextLevel()
        {
            int nextLevelIndex = _currentLevelIndex + 1;

            if (nextLevelIndex >= _characteristicsOfLevels.Length) return null;

            return _characteristicsOfLevels[nextLevelIndex];
        }
        public BuildingConfig GetCurrentLevel() => _characteristicsOfLevels[0];
        /**
         * Метод улучшения характеристик башни, посредством увеличения её уровня.
         * @see SetNewCharacteristics()
        */
        public void SetNextLevel()
        {
            if (this.enabled == false) return;
            if ((_currentLevelIndex + 1) >= _characteristicsOfLevels.Length) return;

            _parent.SetNewCharacteristics(_characteristicsOfLevels[++_currentLevelIndex]);

            Debug.Log(string.Format("Set new Level: {0}", _characteristicsOfLevels[_currentLevelIndex]));
        }

        private void SortLevels()
        {
            for (int i = 1; i < _characteristicsOfLevels.Length; i++)
            {
                BuildingConfig cacheConfig = _characteristicsOfLevels[i];

                int j = i - 1;
                for (; j >= 0 && _characteristicsOfLevels[j].towerLevel > cacheConfig.towerLevel; j--)
                    _characteristicsOfLevels[j + 1] = _characteristicsOfLevels[j];

                _characteristicsOfLevels[j + 1] = cacheConfig;
            }

            Debug.Log("Levels was sorted");
        }
    }
}