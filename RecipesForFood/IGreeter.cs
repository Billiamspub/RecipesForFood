using Microsoft.Extensions.Configuration;

namespace RecipesForFood
{
    public interface IGreeter
    {
        string GetTitleOfTheDay();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration configuration;
        public Greeter(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string GetTitleOfTheDay()
        {
            //return "Greetings!";
            return configuration["AppTitle"];
        }
    }
}