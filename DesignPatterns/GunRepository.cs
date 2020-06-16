using System;

namespace DesignPatterns
{
    public interface GunRepository
    {
        void Save(Gun gun);
        Gun GetById(string id);
    }

    public class Gun
    {
        // Creational - Lazy Singleton
        private static Gun nineeveleven;
        public static Gun GetNineEleven()
        {
            return nineeveleven ?? (nineeveleven = new Gun("0", "Colt 1911"));
        }

        public string Id { get; }
        public string Brand { get; }

        public Gun(string id, string brand)
        {
            Id = id;
            Brand = brand;
        }
    }
}
