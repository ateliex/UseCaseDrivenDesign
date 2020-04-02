namespace System.Web
{
    public abstract class LinkedResourceCollection<T> : LinkedResource where T : LinkedResource
    {
        public T[] Data { get; set; }
    }
}
