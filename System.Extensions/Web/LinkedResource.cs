namespace System.Web
{
    public abstract class LinkedResource
    {
        public string Title { get; set; }

        public string HRef { get; set; }

        public Link[] Links { get; set; }
    }

    public class LinkedResource<T> : LinkedResource
    {
        public T Data { get; set; }
    }
}
