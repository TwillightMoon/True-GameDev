namespace StatsEnums
{
    public enum Levels : byte
    {
        First,
        Second,
        Third,
        Special
    }

    namespace DamageRistances
    {
        public enum DamageResistance : byte
        {
            None,
            Weak,
            Medium,
            Powerfull
        }

        public static class DamageResistances
        {
            public static float GetDamageResistance(DamageResistance damageResistance)
            {
                switch (damageResistance)
                {
                    case DamageResistance.None:
                        return 0f;
                    case DamageResistance.Weak:
                        return 0.25F;
                    case DamageResistance.Medium:
                        return 0.5F;
                    case DamageResistance.Powerfull:
                        return 0.85F;

                    default:
                        return 0f;
                }
            }
        }
    }

    namespace DamageTypes
    {
        public enum DamageType : byte
        {
            Physical,
            Energy,
            Explosive,
            AMY
        }

        public static class DamageTypes
        {
            public static IAttacker GetAttackType(DamageType damageType)
            {
                switch (damageType)
                {
                    case DamageType.Physical:
                        return new PhysicalAttack();
                    case DamageType.Energy:
                        return new EnergyAttack();
                    case DamageType.Explosive:
                        return null;
                    case DamageType.AMY:
                        return null;
                    default:
                        return null;
                }
            }
        }
    }
}