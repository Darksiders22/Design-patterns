using Console = System.Console;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = SimpleGunsFactory.NewColtDefaultGuns();

            var revolver = repo.Save("Colt Revolver");
            var defaultGun = repo.Save("Colt Nine-Eleven");
            Console.WriteLine("{0} {1}", revolver.Id, revolver.Brand);
            Console.WriteLine("{0} {1}", defaultGun.Id, defaultGun.Brand);
        }
    }
}
