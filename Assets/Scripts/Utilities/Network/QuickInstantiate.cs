using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;

    private void Awake()
    {
        Vector2 offset = Random.insideUnitCircle * 3f;
        Vector3 position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);

        MasterManager.NetworkInstantiate(Prefab,position,Quaternion.identity);
    }
}
