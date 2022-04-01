using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    [SerializeField]
    private Renderer selectedRenderer;
    [SerializeField]
    private bool isOn;
    [SerializeField]
    private List<IndexMaterialPair> materials;

    private void Start()
    {
        Swap(isOn);
    }

    public void Swap(bool b)
    {
        isOn = b;
        Material[] newMaterials = selectedRenderer.materials;
        for (int i = 0; i < selectedRenderer.materials.Length; i++)
        {
            foreach (IndexMaterialPair imp in materials)
            {
                if (imp.index == i)
                {
                    newMaterials[i] = b ? imp.materialOn : imp.materialOff;
                }
            }
        }
        selectedRenderer.materials = newMaterials;
    }

    public void TriggerSwap() => Swap(true);

    public void ToggleSwap() => Swap(!isOn);
}

[System.Serializable]
public class IndexMaterialPair
{
    public int index;
    public Material materialOn;
    public Material materialOff;
}
