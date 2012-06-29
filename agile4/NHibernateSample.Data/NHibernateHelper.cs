using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernateSample.Domain;

namespace NHibernateSample.Data
{
     public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory=null;
        public NHibernateHelper(Type type)
        {
            _sessionFactory = GetSessionFactory(type);
        }
        private ISessionFactory GetSessionFactory(Type type)
        {
            Configuration config=new Configuration();
            config.AddClass(type);
            ISessionFactory iSess = config.Configure().BuildSessionFactory();
            return iSess;
        }
        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
