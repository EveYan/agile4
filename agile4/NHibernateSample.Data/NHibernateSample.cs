using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
//using NHibernate.DomainModel.Northwind.Entities;
using NHibernateSample.Domain;
using NHibernate.Cfg;

namespace NHibernateSample.Data
{
    public class NHibernateSample
    {
        protected ISession Session { get; set; }

        public NHibernateSample(ISession session)
        {
            Session = session;
        }
        public NHibernateSample(Type type)
        {
            NHibernateHelper a = new NHibernateHelper(type);
            //ISession Session = NHibernateHelper.GetSession();
            Session = a.GetSession();
        }

        public void CreateCustomer(Customer customer)
        {
            Session.Save(customer);
            Session.Flush();
        }

        public void CreatFile(file file)
        {
            Session.Save(file);
            Session.Flush();
        }

        public Customer GetCustomerById(int customerId)
        {
            return Session.Get<Customer>(customerId);
        }

        public file GetFileById(int fileid)
        {
            return Session.Get<file>(fileid);
        }

        public void changename(Customer cm, string bname)
        {
            cm.name = bname;
            Session.Save(cm);
            Session.Flush();
        }

        public void changename(file fl, string btitle)
        {
            fl.title = btitle;
            Session.Save(fl);
            Session.Flush();
        }

        public virtual void changepassword(Customer cm  ,string bpass)
        {
            cm.password = bpass;
            Session.Save(cm);
            Session.Flush();
        }

        public virtual void changerole(Customer cm ,string brole)
        {
            cm.role=brole;
            Session.Save(cm);
            Session.Flush();
        }


        public virtual void changetype(file fl,string btype)
        {
            fl.type = btype;
            Session.Save(fl);
            Session.Flush();
        }

        public virtual void changetime(file fl)
        {
            DateTime btime = DateTime.Now;
            fl.time = btime;
            Session.Save(fl);
            Session.Flush();
        }

        public virtual void changetext(file fl,string btext)
        {
            fl.text = btext;
            Session.Save(fl);
            Session.Flush();
        }

        public virtual void changeuserid(file fl, int buserid)
        {
            fl.userid = buserid;
            Session.Save(fl);
            Session.Flush();
        }

        public virtual void changepath(file fl, string bpath)
        {
            fl.path = bpath;
            Session.Save(fl);
            Session.Flush();
        }

        public virtual void changeaudit(file fl, string baudit)
        {
            fl.audit = baudit;
            Session.Save(fl);
            Session.Flush();
        }
        public void delete(Customer cm)
        {
            Session.Delete(cm);
            Session.Flush();
        }

        public void delete(file fl)
        {
            Session.Delete(fl);
            Session.Flush();
        }
    }

    
}
