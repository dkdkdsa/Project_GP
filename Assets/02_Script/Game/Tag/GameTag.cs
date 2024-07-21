using UnityEngine;

public class GameTag : MonoBehaviour
{

    [SerializeField] private Tags _tags;

    private void Awake()
    {
        
        ObjectManager.Instance.AddGameTag(gameObject.GetInstanceID(), this);

    }

    public Tags GetTag()
    {

        return _tags;

    }

    public bool HasTag(Tags tag)
    {

        return (_tags & tag) == tag;

    }

    public void AddTag(Tags tag)
    {

        _tags |= tag;

    }

    public void RemoveTag(Tags tag)
    {

        _tags &= ~tag;

    }

    public void SetTag(Tags tag)
    {

        _tags = tag;

    }

    private void OnDestroy()
    {
        
        if(ObjectManager.Instance != null)
        {

            ObjectManager.Instance.RemoveGameTag(gameObject.GetInstanceID());

        }

    }

}
