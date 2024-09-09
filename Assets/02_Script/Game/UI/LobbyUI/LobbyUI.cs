using TMPro;
using UnityEngine;

public class LobbyUI : ExpansionNetworkBehaviour
{

    [SerializeField] private TMP_Text _text;

    public override void OnNetworkSpawn()
    {

        _text.text = HostSingle.Instance.GameManager.JoinCode;

    }

}
