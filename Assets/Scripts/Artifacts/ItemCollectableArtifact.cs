using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableArtifact : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddArtifacts();
    }
}
