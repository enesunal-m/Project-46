using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Constants
{

    public static class UnitContants
    {
        public static string health => "HP";
    }

    public static class DamageConstants
    {
        public static float initalPlayerMultiplier => 1f;
        public static float initalEnemyMultiplier => 1f;
    }

    public static class PlayerConstants
    {
        public static int initialMana => 3;
        public static float initialShield => 20f;
        public static float initalStrength => 20f;
        public static float initialFullHealth => 100f;
    }

    public static class LocationConstants
    {
        public static Vector3 enemyBaseLocation => new Vector3(0, 0, 0);
        public static Vector3 playerBaseLocation => new Vector3(0, 0, 0);

        public static Vector3 rightUpDistanceVector => new Vector3(10, 10, 0);
        public static Vector3 leftUpDistanceVector => new Vector3(-10, 10, 0);
    }
}

// entity or object lists 
public static class Lists
{

    // lists of Norma, Elite and Boss enemies
    public static class EnemyLists
    {
        // tier based lists of Normal enemies
        public static List<EnemyController> tier1_NormalEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier2_NormalEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier3_NormalEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier4_NormalEnemiesList = new List<EnemyController>();

        // tier based lists of Elite enemies
        public static List<EnemyController> tier1_EliteEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier2_EliteEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier3_EliteEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier4_EliteEnemiesList = new List<EnemyController>();

        // tier based lists of Boss enemies
        public static List<EnemyController> tier1_BossEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier2_BossEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier3_BossEnemiesList = new List<EnemyController>();
        public static List<EnemyController> tier4_BossEnemiesList = new List<EnemyController>();

        // lists of all enemy tiers
        public static Dictionary<EnemyTier, List<EnemyController>> normalEnemiesList = new Dictionary<EnemyTier, List<EnemyController>>() 
        {
            { EnemyTier.Tier1, tier1_NormalEnemiesList },
            { EnemyTier.Tier2, tier2_NormalEnemiesList },
            { EnemyTier.Tier3, tier3_NormalEnemiesList },
            { EnemyTier.Tier4, tier4_NormalEnemiesList },
        };
        // lists of all enemy tiers
        public static Dictionary<EnemyTier, List<EnemyController>> eliteEnemiesList = new Dictionary<EnemyTier, List<EnemyController>>()
        {
            { EnemyTier.Tier1, tier1_EliteEnemiesList },
            { EnemyTier.Tier2, tier2_EliteEnemiesList },
            { EnemyTier.Tier3, tier3_EliteEnemiesList },
            { EnemyTier.Tier4, tier4_EliteEnemiesList },
        };
        // lists of all enemy tiers
        public static Dictionary<EnemyTier, List<EnemyController>> bossEnemiesList = new Dictionary<EnemyTier, List<EnemyController>>()
        {
            { EnemyTier.Tier1, tier1_BossEnemiesList },
            { EnemyTier.Tier2, tier2_BossEnemiesList },
            { EnemyTier.Tier3, tier3_BossEnemiesList },
            { EnemyTier.Tier4, tier4_BossEnemiesList },
        };

        public static Dictionary<EnemyType, Dictionary<EnemyTier, List<EnemyController>>> enemyDictionary = 
            new Dictionary<EnemyType, Dictionary<EnemyTier, List<EnemyController>>>();
    }
}

// Enums
public enum Characters // Character type enums
{
    Player,
    Enemy
}
public enum EnemyType // Enemy type enums
{
    Normal,
    Elite,
    Boss
}
public enum EnemyTier // Enemy tier enums
{
    Tier1,
    Tier2,
    Tier3,
    Tier4
}

// withIndex extension for indexed foreach
public static class EnumExtension
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
       => self.Select((item, index) => (item, index));

    public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> self, int take)
    {
        System.Random random = new System.Random();
        int available = self.Count();
        int needed = take;
        foreach (var item in self)
        {
            if (random.Next(available) < needed)
            {
                needed--;
                yield return item;
                if (needed == 0)
                {
                    break;
                }
            }
            available--;
        }
    }
}