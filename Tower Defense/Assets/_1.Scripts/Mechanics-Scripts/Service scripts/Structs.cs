using System;
using Units;

namespace Structs
{
    [Serializable]
    public struct MinMax
    {
        public int min;
        public int max;
    }

    public struct Wawe
    {
        public UnitGroup groups;
    }

    public struct UnitGroup
    {
        public Unit[] units;

    }
}

