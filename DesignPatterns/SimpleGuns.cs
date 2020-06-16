using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface Guns
    {
        Gun Save(string name);

        Gun Get(string id);
    }

    //Structural - Facade
    public class SimpleGuns : Guns
    {
        private GunRepository repository;
        private Validator validator;
        private IdGenerator idGenerator;

        public SimpleGuns(GunRepository repository, Validator validator, IdGenerator idGenerator)
        {
            this.repository = repository;
            this.validator = validator;
            this.idGenerator = idGenerator;
        }

        public Gun Save(string name)
        {
            if (validator.Validate(name))
            {
                var gun = new Gun(idGenerator.NewId(), name);
                repository.Save(gun);
                return gun;
            }

            Console.WriteLine("Brand not valid. Returning Default.");
            return Gun.GetNineEleven();
        }

        public Gun Get(string id)
        {
            return repository.GetById(id);
        }
    }

    public interface IdGenerator
    {
        string NewId();
    }

    public class GlobalUniqueIdGenerator : IdGenerator
    {
        public string NewId()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public interface Validator
    {
        bool Validate(string brand);
    }

    public class LengthValidator : Validator
    {
        private int maxLength;

        public LengthValidator(int maxLength)
        {
            this.maxLength = maxLength;
        }

        public bool Validate(string brand)
        {
            return brand.Length <= maxLength;
        }
    }

    public class ColtValidator : Validator
    {
        public bool Validate(string brand)
        {
            return !brand.ToLower().Equals("colt nine-eleven");
        }
    }

    //Structural - Composite
    public class CompositeValidator : Validator
    {
        private List<Validator> validators;

        public CompositeValidator(List<Validator> validators)
        {
            this.validators = new List<Validator>();
            this.validators.AddRange(validators);
        }


        public bool Validate(string brand)
        {
            bool valid;

            foreach (var validator in validators)
            {
                valid = validator.Validate(brand);
                if (!valid) return false;
            }

            return true;
        }
    }
}
