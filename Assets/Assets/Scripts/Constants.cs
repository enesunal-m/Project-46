using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// Contains global constants of game
/// </summary>
public static class Constants
{
    public static class URLConstants
    {
        public static string cardDatabaseJsonBaseUrl = @"/Assets/Database/CardDatabase_{0}.json";
        public static string enemyDatabaseJsonBaseUrl = @"/Assets/Database/EnemyDatabase.json";
        public static string buffDebuffDatabaseJsonBaseUrl = @"/Assets/Database/BuffDebuffDatabase.json";
        public static string enemyImages = @"/Assets/Sprites/Enemies/enemyImage_{0}_{1}.png";
        public static string cardLogos = @"/Assets/Sprites/Cards/Logos/cardLogo_{0}.png";
        public static string cardImages = @"/Assets/Sprites/Cards/Images/cardImage_{0}.png";
    }

    public static class UnitConstants
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
        public static Vector3 enemyBaseLocation => new Vector3(5, -1, 0);

        public static Vector3 rightUpDistanceVector => new Vector3(1.5f, 1, 0);
        public static Vector3 leftUpDistanceVector => new Vector3(-1.5f, 1, 0);
    }

    public static class CardConstants
    {
        public static int deckCardCount => 50;
    }
}

/// <summary>
/// Lists of entities and objects
/// </summary>
public static class Lists
{
    /// <summary>
    /// Lists and dictionaries of Normal, Elite and Boss enemies
    /// </summary>
    public static class EnemyLists
    {
        // tier based lists of Normal enemies
        public static List<GameObject> tier1_NormalEnemiesList = new List<GameObject>();
        public static List<GameObject> tier2_NormalEnemiesList = new List<GameObject>();
        public static List<GameObject> tier3_NormalEnemiesList = new List<GameObject>();
        public static List<GameObject> tier4_NormalEnemiesList = new List<GameObject>();

        // tier based lists of Elite enemies
        public static List<GameObject> tier1_EliteEnemiesList = new List<GameObject>();
        public static List<GameObject> tier2_EliteEnemiesList = new List<GameObject>();
        public static List<GameObject> tier3_EliteEnemiesList = new List<GameObject>();
        public static List<GameObject> tier4_EliteEnemiesList = new List<GameObject>();

        // tier based lists of Boss enemies
        public static List<GameObject> tier1_BossEnemiesList = new List<GameObject>();
        public static List<GameObject> tier2_BossEnemiesList = new List<GameObject>();
        public static List<GameObject> tier3_BossEnemiesList = new List<GameObject>();
        public static List<GameObject> tier4_BossEnemiesList = new List<GameObject>();

        // lists of all enemy tiers
        public static Dictionary<EnemyTier, List<GameObject>> normalEnemiesList = new Dictionary<EnemyTier, List<GameObject>>() 
        {
            { EnemyTier.Tier1, tier1_NormalEnemiesList },
            { EnemyTier.Tier2, tier2_NormalEnemiesList },
            { EnemyTier.Tier3, tier3_NormalEnemiesList },
            { EnemyTier.Tier4, tier4_NormalEnemiesList },
        };
        // lists of all enemy tiers
        public static Dictionary<EnemyTier, List<GameObject>> eliteEnemiesList = new Dictionary<EnemyTier, List<GameObject>>()
        {
            { EnemyTier.Tier1, tier1_EliteEnemiesList },
            { EnemyTier.Tier2, tier2_EliteEnemiesList },
            { EnemyTier.Tier3, tier3_EliteEnemiesList },
            { EnemyTier.Tier4, tier4_EliteEnemiesList },
        };
        // lists of all enemy tiers
        public static Dictionary<EnemyTier, List<GameObject>> bossEnemiesList = new Dictionary<EnemyTier, List<GameObject>>()
        {
            { EnemyTier.Tier1, tier1_BossEnemiesList },
            { EnemyTier.Tier2, tier2_BossEnemiesList },
            { EnemyTier.Tier3, tier3_BossEnemiesList },
            { EnemyTier.Tier4, tier4_BossEnemiesList },
        };

        public static Dictionary<EnemyType, Dictionary<EnemyTier, List<GameObject>>> enemyDictionary = 
            new Dictionary<EnemyType, Dictionary<EnemyTier, List<GameObject>>>()
            {
                { EnemyType.Normal, normalEnemiesList },
                { EnemyType.Elite, eliteEnemiesList },
                { EnemyType.Boss, bossEnemiesList },
            };

        public static void initEnemy(GameObject gameObject)
        {
            tier1_NormalEnemiesList.Add(gameObject);
            tier2_NormalEnemiesList.Add(gameObject);
        }
    }
}

// Enums
/// <summary>
/// Character types enum
/// </summary>
public enum Characters
{
    Player,
    Enemy
}

// Enemy enums
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
public enum EnemyIntention // Enemy intention enums
{
    None,
    Guard,
    Attack,
    Sleep,
    Buff
}

public enum CardTarget
{
    SingleEnemy,
    Player,
    MultipleEnemies,
    All
}



// End of enemy enums

// General Game enums
public enum Language
{
    tr,
    en
}

public enum CardType
{
    Attack,
    Defense,
    Buff,
    Debuff,
    NonPlayable
}

public enum BuffDebuff
{
    Buff,
    Debuff
}

// End of general game enums


// Hasan buraya göz atarsýn
/// <summary>
/// Contains enumerable extensions that helps to shortly run some processes
/// </summary>
public static class EnumExtension
{
    // withIndex extension for indexed foreach
    /// <summary>
    /// Use this function to get indexes of enumerables with their items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="self"></param>
    /// <returns>items and indexes of enumerable</returns>
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
       => self.Select((item, index) => (item, index));

    /// <summary>
    /// Use this function to get given number of elements of enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="self"></param>
    /// <param name="take"></param>
    /// <returns>items and indexes of enumerable</returns>
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

public static class StringExtension
{
    public static IEnumerable<int> AllIndexesOf(this string self, string searchstring)
    {
        int minIndex = self.IndexOf(searchstring);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = self.IndexOf(searchstring, minIndex + searchstring.Length);
        }
    }

    public static List<string> BetweenAll(this string word, string start, string end)
    {
        return Regex.Matches(word, "{[^}]+}").Cast<Match>()
                .Select(m => m.Groups[0].Value)
                .ToList();
    }
}
