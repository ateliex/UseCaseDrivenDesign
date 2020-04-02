using System.Collections.Generic;

namespace System.Web
{
    public abstract class LinkedResource
    {
        public string Title { get; set; }

        public string HRef { get; set; }

        public List<Link> Links { get; set; }
    }
}
