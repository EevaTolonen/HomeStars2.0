using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEventManager : MonoBehaviour
{
    // instantiate our delegate for boss death 
    public delegate void DeathAction();

    // create event of type DeathAction for other scripts to subscribe to
    public static event DeathAction OnDeath;


    // we call this event from BadGuyController when boss dies
    public static void OnBossDying()
    {
        if (OnDeath != null)
            OnDeath();
    }
}
