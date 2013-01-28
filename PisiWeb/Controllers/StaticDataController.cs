using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel;
using Pisi.MasterData.Contract;

namespace PisiWeb.Controllers
{
    public class StaticDataController : ApiController
    {
        // GET api/staticdata
        public IList<PayrollPeriod> Get()
        {
            var cf = new ChannelFactory<IPayslipChannel>("payslip");
            using (var ch = cf.CreateChannel())
            {
                //int test = ch.AddNumbers(3, 4);
                return ch.FindAllPublishedPeriod();
            }
        }

        // GET api/staticdata/5
        public VerificationEmployee Get(string id)
        {
            var cf = new ChannelFactory<IRegistrationChannel>("signup");
            using (var ch = cf.CreateChannel())
            {
                //int test = ch.AddNumbers(3, 4);
                return ch.GetEmployeeByVerificationKey(id);
            }
           // return "value";
        }

        // POST api/staticdata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/staticdata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/staticdata/5
        public void Delete(int id)
        {
        }
        private void TestConnectToLocal()
        {
            var cf = new ChannelFactory<IRegistrationChannel>("signup");
            using (var ch = cf.CreateChannel())
            {
                //int test = ch.AddNumbers(3, 4);
            }
        }
    }
}
