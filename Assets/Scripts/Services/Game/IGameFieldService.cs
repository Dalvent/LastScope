using LastScope.Logic;

namespace LastScope.Services.Game
{
    public interface IGameFieldService
    {
        ISquare Bounder { get; }
        ISquare DespawnArea { get; }
    }
}