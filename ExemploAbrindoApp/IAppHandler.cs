using System;
using System.Threading.Tasks;

namespace ExemploAbrindoApp
{
    public interface IAppHandler
    {
        Task<bool> LaunchApp(string uri);
    }
}
