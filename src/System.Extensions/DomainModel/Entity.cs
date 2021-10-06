namespace System.DomainModel
{
    public abstract class Entity
    {
        [Infrastructure]
        public byte[] Version { get; set; }
    }
}
