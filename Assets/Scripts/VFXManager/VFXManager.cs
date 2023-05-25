using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
    }

    public List<VFXManagerSetup> vfxSetups;

    public void PlayVFXByType(VFXType vfxType, Vector3 position)
    {
        foreach (var vfx in vfxSetups)
        {
            if (vfx.vfxType == vfxType)
            {
                var item = Instantiate(vfx.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 5f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}
