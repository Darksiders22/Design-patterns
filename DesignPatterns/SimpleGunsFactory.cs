using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //Creational - Method Factory
    public class SimpleGunsFactory
    {
        public static Guns NewColtDefaultGuns()
        {
            var persistence = new PersistentGunRepository();
            var cache = new CachedGunRepository(persistence);
            var validator = new CompositeValidator(new List<Validator>() { new ColtValidator(), new LengthValidator(20) });
            var idGenerator = new GlobalUniqueIdGenerator();

            //Creational - Constructor Dependency Injection
            return new SimpleGuns(cache, validator, idGenerator);
        }
    }
}
