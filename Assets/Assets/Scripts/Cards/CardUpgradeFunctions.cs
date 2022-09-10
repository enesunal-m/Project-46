using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardUpgradeFunctions
{

    public static Dictionary<string, CardUpgradeFunction> cardUpgradeFunctionsDictionary = new Dictionary<string, CardUpgradeFunction>()
    {
        {"attack", new Attack() },
        {"asclepius", new Asclepius() },
        {"truth", new Truth() },
        {"demonicAttack", new DemonicAttack() },
        {"gambler", new Gambler() },
        {"payback", new Payback() },
        {"guard", new Guard() },
        {"holyShield", new HolyShield() },
        {"drugs", new Drugs() },
        {"greedy", new Greedy() },
        {"conscience", new Conscience() },
        {"faith", new Faith() },
        {"takeRisk", new TakeRisk() },
        {"deepBreath", new DeepBreath() }
    };

    public abstract class CardUpgradeFunction
    {
        public abstract void run(CardDatabaseStructure.ICardInfoInterface thisCard);
    }

    public class Attack : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.damage += 2; 
        }
    }
    public class Truth : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.damage += 2;
        }
    }
    public class DemonicAttack : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.damage += 1;
            thisCard.attributes.amount -= 2;
        }
    }
    public class Gambler : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.damageMax += 2;
            thisCard.attributes.damageMin += 2;
        }
    }
    public class Payback : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.damage += 10;
        }
    }
    public class Guard : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.shield += 3;
        }
    }
    public class HolyShield : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.shield += 1;
            thisCard.attributes.amount += 2;
        }
    }
    public class Asclepius : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.perTurn += 1;
        }
    }
    public class Drugs : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            // TODO:
            // Fix Json and complete this function - effects are missing
        }
    }
    public class Greedy : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.amount -= 5;
        }
    }
    public class Conscience : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.amount += 5;
        }
    }
    public class Faith : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.attributes.amount += 5;
        }
    }
    public class DeepBreath : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            thisCard.cost -= 1;
        }
    }
    public class TakeRisk : CardUpgradeFunction
    {
        public override void run(CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            // TODO:
        }
    }
}
