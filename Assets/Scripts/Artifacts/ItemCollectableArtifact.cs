using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableArtifact : ItemCollectableBase
{
    public Collider2D artifactCollider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddArtifacts();
        artifactCollider.enabled = false;
    }
}
