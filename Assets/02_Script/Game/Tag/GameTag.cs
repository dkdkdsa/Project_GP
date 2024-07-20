using UnityEngine;

public class GameTag : MonoBehaviour
{

    [SerializeField] private Tags _tags;

    public Tags GetTag()
    {

        return _tags;

    }

    public bool HasTag(Tags tag)
    {

        return (_tags & tag) == tag;

    }

}
