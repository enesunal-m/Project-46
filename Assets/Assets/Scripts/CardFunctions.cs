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
        public abstract void run(Enemy selectedEnemy, ICardInfoInterface thisCard);
    }

    public class Attack : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {
            selectedEnemy.getDamage(thisCard.attributes.damage);
        }
    }
    public class DemonicAttack : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class Gambler : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class Payback : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class Guard : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class HolyShield : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class Drugs : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class Greedy : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class Conscience : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class Faith : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class DeepBreath : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
    public class TakeRisk : CardFunction
    {
        public override void run(Enemy selectedEnemy, ICardInfoInterface thisCard)
        {

        }
    }
}
