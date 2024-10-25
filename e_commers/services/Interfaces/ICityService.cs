namespace demo.interfaces
{
    public interface ICityService
    {
        public  Task<string> GetCityByName(string city);
    }
}