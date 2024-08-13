using Unity.Mathematics;

public interface IRenderer
{

    public bool2 GetFlip();
    public void SetFlip(bool2 flip);
    public (float, float) GetSpriteSize();
    public void SetSpriteSize(float width, float height);

}
