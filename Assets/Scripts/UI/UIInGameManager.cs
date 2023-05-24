using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI textUI;
    public static void UpdateTextCoins(string s)
    {
        Instance.textUI.text = s;
    }

    public static void UpdateTextArtifacts(string s)
    {
        Instance.textUI.text = s;
    }

}
