using UnityEngine;

public class PlayerFactory : ExpansionMonoBehaviour, IFactory<Player>
{

    [SerializeField] private Player _playerPrefab;

    public Player CreateInstance(PrefabData data = default, object extraData = null)
    {

        return Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);

    }

}
