using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDebuffController : MonoBehaviour
{
    private static BuffDebuffController instance = null;

    public static BuffDebuffController Instance
    {
        get
        {
            if (instance == null)
                instance = new BuffDebuffController();
            return instance;
        }
    }

    public static List<BuffDebuffDatabaseStructure.IBuffDebuffInfoInterface> initalizeBuffDebuffList(BuffDebuffDatabaseStructure.Root buffDebuffDatabaseJson)
    {
        List<BuffDebuffDatabaseStructure.IBuffDebuffInfoInterface> buffDebuffList = new List<BuffDebuffDatabaseStructure.IBuffDebuffInfoInterface>();

        foreach (BuffDebuffDatabaseStructure.IBuffDebuffInfoInterface buff in buffDebuffDatabaseJson.buff)
        {
            BuffDebuff buff_ = BuffDebuff.Buff;
            buff.buffDebuff = buff_;

            buffDebuffList.Add(buff);
        }
        foreach (BuffDebuffDatabaseStructure.IBuffDebuffInfoInterface debuff in buffDebuffDatabaseJson.debuff)
        {
            BuffDebuff debuff_ = BuffDebuff.Debuff;
            debuff.buffDebuff = debuff_;

            buffDebuffList.Add(debuff);
        }

        return buffDebuffList;
    }
}
