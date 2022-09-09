using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardFunctions 
{
    public static Dictionary<string, CardFunction> cardFunctionDictionary = new Dictionary<string, CardFunction>() 
    {
        {"attack", new Attack() },
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

    public static Dictionary<string, CardFunction> customCardFunctionDictionary = new Dictionary<string, CardFunction>()
    {
        {"asclepius", new AsclepiusEffect() },
    };


    public abstract class CardFunction
    {
        public abstract void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard);
    }

    public class Attack : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            selectedEnemies[0].getDamage(thisCard.attributes.damage);
        }
    }
    public class Truth : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            Debug.Log(thisCard.cardTarget);
            selectedEnemies[0].getTrueDamage(thisCard.attributes.damage);
        }
    }
    public class DemonicAttack : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            selectedEnemies[0].getDamage(thisCard.attributes.damage);
            LiarMeterConroller.Instance.liarValue += thisCard.attributes.amount ;
        }
    }
    public class Gambler : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            selectedEnemies[0].getDamage(UnityEngine.Random.Range(thisCard.attributes.damageMin, thisCard.attributes.damageMax + 1));
            LiarMeterConroller.Instance.setLiarValue(thisCard.attributes.amount);
        }
    }
    public class Payback : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            int liarValue = LiarMeterConroller.Instance.liarValue;
            int damageValue = 0;
            if (liarValue <= 50)
            {
                damageValue = thisCard.attributes.damage / 2;
            } else
            {
                damageValue = thisCard.attributes.damage / 2 + thisCard.attributes.damage^2 / 2 / 50;
            }
            selectedEnemies[0].getDamage(damageValue);
        }
    }
    public class Guard : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            GameManager.Instance.playerController.changeShield(thisCard.attributes.shield);
        }
    }
    public class HolyShield : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            GameManager.Instance.playerController.changeShield(thisCard.attributes.shield);

            LiarMeterConroller.Instance.liarValue -= thisCard.attributes.amount;
        }
    }
    public class Asclepius : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            GameManager.Instance.playerController.changeHealth(thisCard.attributes.health);
        }
    }
    public class AsclepiusEffect : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            PlayerController.Instance.nextTurnHealthDelta = thisCard.attributes.perTurn;
        }
    }
    public class Drugs : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            // TODO:
            // Fix Json and complete this function - effects are missing
        }
    }
    public class Greedy : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - effects are missing
            GameManager.Instance.playerDamageMultiplier = GameManager.Instance.playerDamageMultiplier * 2;
            LiarMeterConroller.Instance.setLiarValue(thisCard.attributes.amount);
        }
    }
    public class Conscience : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - effects are missing
            GameManager.Instance.playerDamageMultiplier = GameManager.Instance.playerDamageMultiplier * 2;
            GameManager.Instance.playerController.nextTurnDamageMultiplier = 0.5f;
            LiarMeterConroller.Instance.setLiarValue(-thisCard.attributes.amount);
            Debug.Log("card used");
        }
    }
    public class Faith : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - mana amount is missing in Json
            LiarMeterConroller.Instance.liarValue -= thisCard.attributes.amount;
            GameManager.Instance.playerController.playerMana += 1;
        }
    }
    public class DeepBreath : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            LiarMeterConroller.Instance.liarValue = 50;
        }
    }
    public class TakeRisk : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDatabaseStructure.ICardInfoInterface thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - mana amount and decrease in next turn function are missing in Json
            GameManager.Instance.playerController.playerMana += 1;
            GameManager.Instance.playerController.nextTurnManaDelta = -1;
        }
    }
}
