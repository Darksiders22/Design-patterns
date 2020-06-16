using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //Behavioral - Chain of Responsibility
    public class CachedGunRepository : GunRepository
    {
        private Dictionary<string, Gun> cachedGuns;
        private GunRepository origin;

        public CachedGunRepository(GunRepository origin)
        {
            this.origin = origin;
            cachedGuns = new Dictionary<string, Gun>();
        }

        public void Save(Gun gun)
        {
            origin.Save(gun);
            cachedGuns.Add(gun.Id, gun);
        }

        public Gun GetById(string id)
        {
            if (!cachedGuns.TryGetValue(id, out var gun))
            {
                gun = origin.GetById(id);
                cachedGuns.Add(gun.Id, gun);
            }

            return gun;
        }
    }
}
