using UnityEngine;

public class GroundSencer : ExpansionMonoBehaviour, ISencer
{

    private bool _isSencing;

    public bool IsSencing()
    {

        return _isSencing;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        _isSencing = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        _isSencing = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        _isSencing = false;

    }

}
