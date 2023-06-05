using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace Structs
{
    [Serializable]
    public struct MinMax
    {
        public int min;
        public int max;
    }

    namespace WaveStruct
    {
        [Serializable]
        public struct UnitGroup
        {
            public Unit[] _units;
            public int _currentUnit;

            public int unitCount => _units.Length;

            public Unit Get(int index)
            {
                if (index < _units.Length)
                    return _units[index];
                else
                    return null;
            }
        }

        [Serializable]
        public struct Wave
        {
            public UnitGroup[] _unitGroups;
            public int _currentGroupIndex;

            [Tooltip("Сколько времени уделяется на волну. \"0\" - Следующая волна не наступит, пока не закончится эта.")]
            public float _timeForWave;
            public float _timeBetweenGroups;

            public int currentGroupIndex => _currentGroupIndex;
            public int groupCount => _unitGroups.Length;
            public float timeForWave => _timeForWave;
            public float timeBetweenGroups => _timeBetweenGroups;

            public UnitGroup currentGroup => _unitGroups[_currentGroupIndex];


            public UnitGroup GetUnitGroup(int index)
            {
                if (_unitGroups.Length == 0) return new UnitGroup();

                if (index < _unitGroups.Length)
                    return _unitGroups[index];

                return _unitGroups[0];
            }
        }
    }
}

