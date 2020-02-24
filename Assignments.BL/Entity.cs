namespace Assignments.BL
{
    public class Entity
    {
        public string ID { get; protected set; }

        public Entity(string id)
        {
            ID = id;
        }
    }
}
