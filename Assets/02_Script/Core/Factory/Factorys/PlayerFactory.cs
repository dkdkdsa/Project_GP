using UnityEngine;

public class PlayerFactory : ExpansionMonoBehaviour, IFactory<Player>
{

    [SerializeField] private Player _playerPrefab;

    public Player CreateInstance(PrefabData data = default)
    {

        return Instantiate(_playerPrefab);

    }

}
