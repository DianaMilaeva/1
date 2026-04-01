// спроектировать сущность представляющу музыкальный проигрыватель

/*
class MusicPlayer
{
    private PlayerState state;
    public void SetState(PlayerState state) => this.state = state;
    public MusicPlayer() => state = new StopedState();
    public void Play() => state.Play(this);
    public void Pause() => state.Pause(this);
    public void Stop() => state.Stop(this);
}
class PlayerState
{
    public virtual void Play(MusicPlayer player) { }
    public virtual void Pause(MusicPlayer player) { }
    public virtual void Stop(MusicPlayer player) { }
}
class PlayingState : PlayerState
{
    public override void Play(MusicPlayer player)
    {
        Console.WriteLine("Музыка уже воспроизводится");
    }
    public override void Pause(MusicPlayer player)
    {
        Console.WriteLine("Пауза воспроизведения");
        player.SetState(new PausedState());
    }
    public override void Stop(MusicPlayer player)
    {
        Console.WriteLine("Остановка воспроизведения");
        player.SetState(new StopedState());
    }
}
class PausedState : PlayerState
{
    public override void Play(MusicPlayer player)
    {
        Console.WriteLine("Начало воспроизводения");
        player.SetState(new PlayingState());
    }
    public override void Pause(MusicPlayer player)
    {
        Console.WriteLine("Пауза уже стоит");
    }
    public override void Stop(MusicPlayer player)
    {
        Console.WriteLine("Остановка воспроизведения");
        player.SetState(new StopedState());
    }
}
class StopedState : PlayerState
{
    public override void Play(MusicPlayer player)
    {
        Console.WriteLine("Начало воспроизводения");
        player.SetState(new PlayingState());
    }
    public override void Pause(MusicPlayer player)
    {
        Console.WriteLine("Нельзя поставить на паузу. Воспроизведение остановлено");
    }
    public override void Stop(MusicPlayer player)
    {
        Console.WriteLine("Воспроизведение остановлено");
    }
}
class Program
{
    static void Main(string[] args)
    {
        MusicPlayer player = new MusicPlayer();
        player.Play();
        player.Play();
        player.Pause();
        player.Play();
        player.Stop();
        player.Stop();
    }
}*/