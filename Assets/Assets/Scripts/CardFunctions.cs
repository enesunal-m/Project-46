using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardFunctions 
{
    public static Dictionary<string, CardFunction> cardFunctionDictionary = new Dictionary<string, CardFunction>() 
    {
        {"attack", new Attack() },
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

    public abstract class CardFunction
    {
        public abstract void run(List<Enemy> selectedEnemies, CardDisplay thisCard);
    }

    public class Attack : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            selectedEnemies[0].getDamage(thisCard.attributes.damage);
        }
    }
    public class DemonicAttack : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            selectedEnemies[0].getDamage(thisCard.attributes.damage);
            LiarMeterConroller.Instance.liarValue += thisCard.attributes.amount ?? 0 ;
        }
    }
    public class Gambler : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            selectedEnemies[0].getDamage(UnityEngine.Random.Range(thisCard.attributes.damageMin, thisCard.attributes.damageMax + 1));
            LiarMeterConroller.Instance.setLiarValue(thisCard.attributes.amount ?? 0);
        }
    }
    public class Payback : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
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
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            GameManager.Instance.playerController.changeShield(thisCard.attributes.shield);
        }
    }
    public class HolyShield : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            GameManager.Instance.playerController.changeShield(thisCard.attributes.shield);

            LiarMeterConroller.Instance.liarValue -= thisCard.attributes.amount ?? 0;
        }
    }
    public class Drugs : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            // TODO:
            // Fix Json and complete this function - effects are missing
        }
    }
    public class Greedy : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - effects are missing
            GameManager.Instance.playerDamageMultiplier = GameManager.Instance.playerDamageMultiplier * 2;
            LiarMeterConroller.Instance.setLiarValue(thisCard.attributes.amount ?? 0);
        }
    }
    public class Conscience : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - effects are missing
            GameManager.Instance.playerDamageMultiplier = GameManager.Instance.enemyDamageMultiplier * 2;
            GameManager.Instance.playerController.nextTurnDamageMultiplier = 0.5f;
            LiarMeterConroller.Instance.setLiarValue(-thisCard.attributes.amount ?? 0);
            Debug.Log("card used");
        }
    }
    public class Faith : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - mana amount is missing in Json
            LiarMeterConroller.Instance.liarValue -= thisCard.attributes.amount ?? 0;
            GameManager.Instance.playerController.playerMana += 1;
        }
    }
    public class DeepBreath : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            LiarMeterConroller.Instance.liarValue = 50;
        }
    }
    public class TakeRisk : CardFunction
    {
        public override void run(List<Enemy> selectedEnemies, CardDisplay thisCard)
        {
            // TODO:
            // Fix Json and complete this functions - mana amount and decrease in next turn function are missing in Json
            GameManager.Instance.playerController.playerMana += 1;
            GameManager.Instance.playerController.nextTurnManaDelta = -1;
        }
    }
}
