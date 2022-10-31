
namespace Models
{
    public abstract class Entity
    {
        public string Name { get; set; }

        public Entity(string name)
        {
            Name = name;
        }
        public Entity()
        {

        }
    }
}
