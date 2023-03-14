using Assessment.XT.GLobal.data;
using Assessment.XT.GLobal.Dtos;
using Assessment.XT.GLobal.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assessment.XT.GLobal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomJokeController : ControllerBase
    {
      
        private readonly IRandomJoke _randomJoke;
        private readonly IMapper _mapper;

        public RandomJokeController(IRandomJoke randomJoke, IMapper mapper)
        {
            _randomJoke = randomJoke;
            _mapper = mapper;
        }

        [HttpGet("GetRandomJoke")]
        public async Task<RandomJokeDtos> Get()
        {
            return _mapper.Map<RandomJokeDtos>(await _randomJoke.GetJoke());
        }
        [HttpGet("GetJokeCount")]
        public async Task<JokeCountDto> GetJokeCount()
        {
            return _mapper.Map<JokeCountDto>(await _randomJoke.GetJokeCount());
        }
    }
}