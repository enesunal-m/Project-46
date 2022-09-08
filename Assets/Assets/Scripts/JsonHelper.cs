using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardDatabaseStructure
{
    public class ICardInfoInterface
    {
        public string uuid { get; set; }

        public string id { get; set; }
        public string name { get; set; }
        public CardTarget cardTarget { get; set; }
        public CardTier tier { get; set; }
        public string description { get; set; }
        public List<string> types { get; set; }
        public int cost { get; set; }
        public Attributes attributes { get; set; }
    }

    // <auto-generated />
    //
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var JsonHelper = JsonHelper.FromJson(jsonString);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Attributes
    {
        public int damage { get; set; }
        public int shield { get; set; }
        public int health { get; set; }
        public int perTurn { get; set; }
        public object effects { get; set; }
        public int? amount { get; set; }
        public int damageMin { get; set; }
        public int damageMax { get; set; }
    }

    public class Player : ICardInfoInterface
    {
    }

    public class Root
    {
        public List<SingleEnemy> singleEnemy { get; set; }
        public List<Player> player { get; set; }
        public List<object> mutlipleEnemies { get; set; }
        public List<object> all { get; set; }
    }

    public class SingleEnemy : ICardInfoInterface
    {
    }
}

public static class EnemyDatabaseStructure
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class IEnemyTierInterface
    {
        public List<Tier1> Tier1 { get; set; }
        public List<Tier2> Tier2 { get; set; }
        public List<Tier3> Tier3 { get; set; }
        public List<Tier4> Tier4 { get; set; }
    }

    public class Boss : IEnemyTierInterface
    {
    }

    public class Elite : IEnemyTierInterface
    {
    }

    public class Normal : IEnemyTierInterface
    {
    }

    public class Root
    {
        public Normal Normal { get; set; }
        public Elite Elite { get; set; }
        public Boss Boss { get; set; }
    }

    public class IEnemyInfoInterface
    {
        public string id { get; set; }
        public string name { get; set; }
        public int health { get; set; }
        public int strength { get; set; }
        public int shield { get; set; }
        public List<object> buffs { get; set; }
        public string passive { get; set; }

        public EnemyType enemyType { get; set; }
        public EnemyTier enemyTier { get; set; }
    }

    public class Tier1 : IEnemyInfoInterface
    {  
    }
    public class Tier2 : IEnemyInfoInterface
    {
    }
    public class Tier3 : IEnemyInfoInterface
    {
    }
    public class Tier4: IEnemyInfoInterface
    {
    }
}

public class BuffDebuffDatabaseStructure
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Attributes
    {
        public int? amount { get; set; }
    }

    public class IBuffDebuffInfoInterface
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Attributes attributes { get; set; }

        public BuffDebuff buffDebuff { get; set; }
    }

    public class Buff:IBuffDebuffInfoInterface
    {

    }

    public class Debuff: IBuffDebuffInfoInterface
    {

    }

    public class Root
    {
        public List<Buff> buff { get; set; }
        public List<Debuff> debuff { get; set; }
    }


}
