using Unity.Netcode;

public class NetworkHitCaster : ExpansionNetworkBehaviour, ILocalInject
{

    private IHitCaster _targetCaster;

    public void LocalInject(ComponentList list)
    {

        _targetCaster = list.Find<IHitCaster>();

    }

    public override void OnNetworkSpawn()
    {

        if (IsOwner)
        {

            _targetCaster.OnCasting += HandleOnCasting;

        }

    }

    private bool HandleOnCasting(CastData data)
    {

        SendCastingServerRPC(data);

        return false;

    }

    [ServerRpc]
    private void SendCastingServerRPC(CastData data)
    {

        _targetCaster.CastingDamage(in data, x =>
        {

            if(x.TryGetComponent<INetworkObjectController>(out var compo))
            {
                NetworkGameManager.Instance.AttackPlayer(compo.GetOwner(), OwnerClientId);
            }

        });
        _targetCaster.CastingKnockback(in data);
        
    }

}
