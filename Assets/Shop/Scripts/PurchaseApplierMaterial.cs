using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseApplierMaterial : PurchaseApplier
{
    public List<MeshRenderer> itemsToSetMaterial;
    public List<SkinnedMeshRenderer> skinnedMeshRenderersToSetMaterial;
    public int materialIndex;// Which material to change in the above meshrenderer

    public List<Material> materials;

    public bool theBool;
    public override void Start()
    {
        base.Start();
    }

    public override void ApplyPurchase()
    {
        base.ApplyPurchase();
        SetMaterial(PlayerPrefs.GetInt(itemId + "Selected"));

    }

    public override void Preview(int index)
    {
        base.Preview(index);
        SetMaterial(index);

    }

    void SetMaterial(int index)
    {
        foreach (MeshRenderer meshRenderer in itemsToSetMaterial)
        {
            Material[] _materials;
            _materials = meshRenderer.materials;

            _materials[materialIndex] = materials[index];

            meshRenderer.materials = _materials;
        }

        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderersToSetMaterial)
        {
            Material[] _materials;

            _materials = skinnedMeshRenderer.materials;

            _materials[materialIndex] = materials[index];

            skinnedMeshRenderer.materials = _materials;
        }
    }

}
