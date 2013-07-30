using System;
using System.Collections.Generic;

namespace NhibernateInMemory
{
    public class Post
    {
        public virtual Int32 PostId { get; set; }
        public virtual String PostTitle { get; set; }
        public virtual String PostContent { get; set; }
    }
}
