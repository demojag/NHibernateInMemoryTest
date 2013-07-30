using FluentNHibernate.Mapping;

namespace NhibernateInMemory
{
   
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {

            //SchemaAction.None();  Test will fail. this option hide the schema exportation.

            Id(x => x.PostId);
            Map(x => x.PostTitle);
            Map(x => x.PostContent);
        }
    }
}
