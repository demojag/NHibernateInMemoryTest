using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace NhibernateInMemory
{
    public class Context
    {
        private readonly ISession _session;

        public Context(ISession session)
        {
            if (session == null) throw new ArgumentNullException("session");
            _session = session;
        }


    }
}
