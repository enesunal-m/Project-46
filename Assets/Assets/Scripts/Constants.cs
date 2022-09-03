using System.Collections;
using System.Collections.Generic;
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
}
