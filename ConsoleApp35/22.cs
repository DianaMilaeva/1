interface IPlayer
{
    void Play();
    void Pause();
    void Stop();
}

class MusicPlayer : IPlayer
{
    public void Play()
    {
        Console.WriteLine("Воспроизведение");
    }

    public void Pause()
    {
        Console.WriteLine("Пауза");
    }

    public void Stop()
    {
        Console.WriteLine("Остановка");
    }
}

class Program
{
    static void Main()
    {
        MusicPlayer mp = new MusicPlayer();
        mp.Play();
        mp.Pause();
        mp.Stop();
    }
}