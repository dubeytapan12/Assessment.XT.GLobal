using Assessment.XT.GLobal.data;

namespace Assessment.XT.GLobal.Repository
{
    public interface IRandomJoke
    {
        Task<JokeSchema> GetJoke();
        Task<JokeCountSchema> GetJokeCount();
    }
}
