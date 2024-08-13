using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{

    public void LoadMap(int mapNumber)
    {

        var prefab = ResourceManager.Instance.LoadAsset<GameObject>($"Map_{mapNumber}");

        Instantiate(prefab, Vector3.zero, Quaternion.identity);

    }

}