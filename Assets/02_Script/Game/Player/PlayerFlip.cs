using Unity.Mathematics;

public class PlayerFlip : ExpansionMonoBehaviour, ILocalInject
{

    private IRenderer _renderer;
    private IMoveable _move;

    public void LocalInject(ComponentList list)
    {

        _renderer = list.Find<IRenderer>();
        _move = list.Find<IMoveable>();

    }

    private void Update()
    {

        CheckFlip();

    }

    private void CheckFlip()
    {

        _renderer.SetFlip(new bool2(!_move.IsRight(), false));

    }

}
