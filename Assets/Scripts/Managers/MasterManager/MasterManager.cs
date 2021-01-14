using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


[CreateAssetMenu(menuName ="Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings gameSettings;
    public static GameSettings GameSettings { get { return Instance.gameSettings; } }
    [SerializeField]
    private List<NetworkedPrefab> networkedPrefab = new List<NetworkedPrefab>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        
        Debug.Log("CHECKNET!!");
        foreach (NetworkedPrefab networkedPrefab in Instance.networkedPrefab)
        {
            if(networkedPrefab.Prefab == obj)
            {
                if(networkedPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, rotation);
                    return result;
                }
                else
                {
                    Debug.LogError("Path is empty for gameObject name " + networkedPrefab.Prefab);
                    return null;
                }
                
            }
        }

        return null;
    }


   [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public void PopulateNetworkedPrefabs()
    {
        Debug.Log("CHECK!");
#if UNITY_EDITOR

        Instance.networkedPrefab.Clear();
        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance.networkedPrefab.Add(new NetworkedPrefab(results[i], path));
            }
        }

        for (int i = 0; i < Instance.networkedPrefab.Count; i++)
        {
            UnityEngine.Debug.Log(Instance.networkedPrefab[i].Prefab.name + "," + Instance.networkedPrefab[i].Path);
        }
#endif
    }
}
