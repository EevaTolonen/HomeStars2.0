using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSpriteVisibility : MonoBehaviour
{
    // manages visibility of second level entrance
    // listens to a dying event from the boss and becomes visible when boss dies

    public GameObject wormHole;
    // Start is called before the first frame update
    void Start()
    {
        wormHole.SetActive(false);
        BossEventManager.OnDeath += ChangeVisibility;
    }


    public void ChangeVisibility()
    {
        wormHole.SetActive(true);
        BossEventManager.OnDeath -= ChangeVisibility;
    }
}
