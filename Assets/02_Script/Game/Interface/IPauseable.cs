public interface IPauseable
{

    public bool IsPaused { get; set; }
    public void Pause()
    {

        IsPaused = true;

        DoPause();

    }

    public void Resume()
    {

        IsPaused = false;

        DoResume();

    }

    public void DoPause();
    public void DoResume();

}
