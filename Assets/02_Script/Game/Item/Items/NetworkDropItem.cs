using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NetworkDropItem<T> : ExpansionNetworkBehaviour, IItem<T>
{

    [SerializeField] protected string _prefabKey;
    [SerializeField] private bool _getAndDestroy;

    public abstract void GetItem(T targetHandler);

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var tag = ObjectManager.Instance.FindGameTag(collision.gameObject.GetInstanceID());

        if (tag == null) return;

        if (tag.TryGetComponent<IPauseable>(out var compo))
            if (compo.IsPaused) return;


        if (tag.HasTag(Tags.ItemGet))
        {

            GetItem(collision.gameObject.GetComponent<T>());

            if (_getAndDestroy)
            {

                Despawn();

            }

        }


    }

}
