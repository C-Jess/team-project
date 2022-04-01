using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectSpawner : MonoBehaviour
{
    GameObject spawned;

    private void Start()
    {
        ItemInspector.inspectionItem.AddListener(SpawnItem);
    }

    private void OnDestroy()
    {
        ItemInspector.inspectionItem.RemoveListener(SpawnItem);
    }

    private void SpawnItem(ItemObject obj)
    {
        if (obj.prefab != null)
        {
            if (spawned != null)
            {
                Destroy(spawned);
            }
            spawned = Instantiate(obj.prefab, transform);
        }
        else
        {
            Debug.LogWarning($"<color=yellow>Warning:</color> item \"<color=white>{obj.name}</color>\" doesn't have a <color=cyan>prefab</color>");
        }
    }

    private void OnDisable()
    {
        if (spawned != null)
        {
            Destroy(spawned);
        }
    }
}
