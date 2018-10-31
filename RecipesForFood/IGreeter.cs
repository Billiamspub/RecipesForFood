namespace RecipesForFood
{
    public interface IGreeter
    {
        string GetTitleOfTheDay();
    }

    public class Greeter : IGreeter
    {
        public string GetTitleOfTheDay()
        {
            return "Greetings!";
        }
    }
}