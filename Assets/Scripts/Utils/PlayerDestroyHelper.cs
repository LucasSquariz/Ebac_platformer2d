using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    internal Player player;

    public void KillPlayer()
    {
        player.DestroyPlayer();
    }
}
