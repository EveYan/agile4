using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NHibernateSample.Data;
using NHibernateSample.Domain;
using NHibernate;

namespace NHibernateSample
{
    [TestClass]
    public class NHibernateSampleFixture
    {
        private NHibernateSample.Data.NHibernateSample _sample,_sample2;

        [TestMethod]
        public void TestFixtureSetupC()
        {
            _sample = new NHibernateSample.Data.NHibernateSample(typeof(Customer));
            
        }

        [TestMethod]
        public void TestFixtureSetupF()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));

        }

        

       

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            _sample = new NHibernateSample.Data.NHibernateSample(typeof(Customer));

            //this will be delete at the deleteC method in the end 
            //so that it will success the next time run this whole TEST
            var tempCutomer = new Customer { id=16,name = "永京" };
            _sample.CreateCustomer(tempCutomer);

            Customer customer = _sample.GetCustomerById(1);           
            int customerId = customer.id;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, customerId);
        }

        
        /// 创建
        /// 
        [TestMethod]
        public void GetfileByIdTest()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));

            //this will be delete at the deleteF1 method in the end 
            //so that it will success the next time run this whole TEST
            var tempfile = new file {id = 16, title = "Javahomework" };
            _sample2.CreatFile(tempfile);

            file fl = _sample2.GetFileById(16);
            int fileId = fl.id;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(16, fileId);
        }
        

        /// 这里再重构——update
        /*
        [TestMethod]
        public void updatecustomer()
        {
            Customer cm;
            cm = _sample.GetCustomerById(1);
            cm.name = "混蛋";
            string name = _sample.GetCustomerById(1).name;
            Assert.AreEqual("混蛋", name);
        }
        */

        /*重构第二次——update
        [TestMethod]
        public void updateCname()
        {
            Customer cm;
            cm = _sample.GetCustomerById(1);
            cm.changename("混蛋");
            string name = _sample.GetCustomerById(1).name;
            Assert.AreEqual("混蛋", name);
        }

        [TestMethod]
        public void updateFname()
        {
            file fl;
            fl = _sample.GetFileById(1);
            fl.changename("文件snoopy");
            string name = _sample.GetFileById(1).title;
            Assert.AreEqual("文件snoopy", name);
        }
         */

        /*
        [TestMethod]
        public void updateCname()
        {
            Customer cm= _sample.GetCustomerById(1);
            _sample.changename(cm,"混蛋");
            string name = _sample.GetCustomerById(1).name;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("混蛋", name);
        }
         * */

        [TestMethod]
        public void updateCname()
        {
            _sample = new NHibernateSample.Data.NHibernateSample(typeof(Customer));
            Customer cm = _sample.GetCustomerById(1);
            _sample.changename(cm, "mikey");
            string name = _sample.GetCustomerById(1).name;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("mikey", name);
        }


        [TestMethod]
        public void updateFname()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            file fl= _sample2.GetFileById(11);
            _sample2.changename(fl,"文件snoopy");
            string name = _sample2.GetFileById(11).title;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("文件snoopy", name);
        }

        [TestMethod]
        public void updateCpass()
        {
            _sample = new NHibernateSample.Data.NHibernateSample(typeof(Customer));
            Customer cm = _sample.GetCustomerById(22);
            _sample.changepassword(cm,"skyisblue");
            string password = _sample.GetCustomerById(22).password;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("skyisblue", password);
        }

        [TestMethod]
        public void updateFtype()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            file fl = _sample2.GetFileById(12);
            _sample2.changetype(fl,"study");
            string type = _sample2.GetFileById(12).type;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("study", type);
        }

        [TestMethod]
        public void updateFtime()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            DateTime dt = DateTime.Now;
            file fl = _sample2.GetFileById(16);
            _sample2.changetime(fl);
            DateTime time = _sample2.GetFileById(16).time;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(dt, time);
        }


        [TestMethod]
        public void updateFtext()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            file fl = _sample2.GetFileById(11);
            _sample2.changetext(fl,"I hate agile!");
            string text = _sample2.GetFileById(11).text;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("I hate agile!", text);
        }


        [TestMethod]
        //this will be delete at the deleteC1 method in the end 
        //so that it will success the next time run this whole TEST
        public void insertCustomer()
        {
            _sample = new NHibernateSample.Data.NHibernateSample(typeof(Customer));
            var tempCutomer = new Customer { id = 36, name = "DongJing", password = "minjie" };
            _sample.CreateCustomer(tempCutomer);
            Customer cm = _sample.GetCustomerById(36);
            string name = cm.name;
            string password = cm.password;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("DongJing", name);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("minjie", password);
        }

        [TestMethod]
        //this will be delete at the deleteF2 method in the end 
        //so that it will success the next time run this whole TEST
        public void insertFile()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            var tempFile = new file { id = 18, title = "week1-Java", type = "study", time = DateTime.Now, text = "Programming" };
            _sample2.CreatFile(tempFile);
            file fl = _sample2.GetFileById(18);
            string title = fl.title;
            string type = fl.type;
            DateTime time = fl.time;
            string text = fl.text;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("week1-Java", title);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("study", type);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(DateTime.Now, time);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Programming", text);
        }

        [TestMethod]
        public void deleteC()
        {
            _sample = new NHibernateSample.Data.NHibernateSample(typeof(Customer));
            var tempcm = _sample.GetCustomerById(16);
            _sample.delete(tempcm);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(_sample.GetCustomerById(16)!=null);
        }

        [TestMethod]
        public void deleteC1()
        {
            _sample = new NHibernateSample.Data.NHibernateSample(typeof(Customer));
            var tempcm = _sample.GetCustomerById(36);
            _sample.delete(tempcm);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(_sample.GetCustomerById(16) != null);
        }

        [TestMethod]
        public void deleteF()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            var tempfl = _sample2.GetFileById(7);
            _sample2.delete(tempfl);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(_sample2.GetFileById(7) != null);
        }

        [TestMethod]
        public void delteF1()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            var tempfl = _sample2.GetFileById(16);
            _sample2.delete(tempfl);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(_sample2.GetFileById(7) != null);
        }

        [TestMethod]
        public void delteF2()
        {
            _sample2 = new NHibernateSample.Data.NHibernateSample(typeof(file));
            var tempfl = _sample2.GetFileById(18);
            _sample2.delete(tempfl);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(_sample2.GetFileById(7) != null);
        }
    }
}
