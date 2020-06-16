using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class PersistentGunRepository : GunRepository
    {
        private Dictionary<string, Gun> persistentGuns;

        public PersistentGunRepository()
        {
            persistentGuns = new Dictionary<string, Gun>();
        }

        public void Save(Gun gun)
        {

            persistentGuns.Add(gun.Id, gun);

        }

        public Gun GetById(string id)
        {

            return persistentGuns[id];

        }
    }
}
