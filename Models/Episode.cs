using System;

namespace Models
{
    [Serializable]
    public class Episode : Entity
    {
        public string Description { get; set; }
        public Episode(string name, string description) : base(name)
        {
            Description = description;
        }
    }
}
