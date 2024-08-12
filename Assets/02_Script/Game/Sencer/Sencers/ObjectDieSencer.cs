using UnityEngine;

public class ObjectDieSencer : ExpansionMonoBehaviour, ISencer, IPauseable
{
    public bool IsPaused { get; set; }

    public void DoPause()
    {

    }

    public void DoResume()
    {

    }

    public bool IsSencing()
    {

        return false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (IsPaused) return;

        var tag = ObjectManager.Instance.FindGameTag(collision.GetGameObjectId());

        if (tag == null) return;

        if (tag.HasTag(Tags.Dieable))
        {

            tag.GetComponent<IDieable>().Die();

        }

    }

}
