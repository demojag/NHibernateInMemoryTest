using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NhibernateInMemory
{
    [TestFixture]
    public class Test
    {
        private static Configuration _savedConfig;

        public static ISessionFactory CreateSessionFactory()
        {
            return
                Fluently
                    .Configure()
                    .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(c => _savedConfig = c)
                    .BuildSessionFactory();
        }

        public static void BuildSchema(ISession session)
        {
            var export = new SchemaExport(_savedConfig);
            export.Execute(true, true, false, session.Connection, null);
        }
        


        [Test]
        public void UseInMemoryDb()
        {
            var sessionFactory = CreateSessionFactory();
            
            using (var session = sessionFactory.OpenSession())
            {
                BuildSchema(session);

                const string postContent = "test";
                const string postTitle = "TestTitle";

                using (var transaction = session.BeginTransaction())
                {
                    var post = new Post {PostContent = postContent, PostId = 1, PostTitle = postTitle};
                    session.Save(post);
                    transaction.Commit();
                }

                var result = session.Get<Post>(1);
                Assert.That(result != null);
                Assert.That(result.PostContent.Equals(postContent));
            }
        }
    }
}
