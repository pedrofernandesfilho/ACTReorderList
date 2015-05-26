using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Infra.Data.EF.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ACTReorderList.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // EF Test

            TaskRepository tr = new TaskRepository();

            IEnumerable<Task> tasks = tr.GetAll();

            System.Console.BackgroundColor = System.ConsoleColor.DarkBlue;
            System.Console.WriteLine("Count: {0}", tasks.Count());

            System.Console.ReadKey();
        }
    }
}