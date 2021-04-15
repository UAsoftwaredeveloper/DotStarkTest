using System;
using Mail;
using AdoRepositrory;
using Models;
using System.Collections.Generic;
using Constants;
namespace BusinessLogic
{
    public class BusinessLogic
    {
        private AdoExecution AdoExecution = new AdoExecution(ConstantFields.ConnectionString);
        private TextMail tm = new TextMail(ConstantFields.MailClient, ConstantFields.MailUserId, ConstantFields.MailPassword, Convert.ToInt32(ConstantFields.Mailport));
        public int InsertContactDetail(ContactUs contactUs)
        {
            try
            {
                int result = 0;
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                keyValuePairs.Clear();
                keyValuePairs.Add("@Name", contactUs.Name);
                keyValuePairs.Add("@Email", contactUs.Email);
                keyValuePairs.Add("@Phone", contactUs.Contact);
                keyValuePairs.Add("@Purpose", contactUs.Porpose);
                keyValuePairs.Add("@Matter", contactUs.Description);
                result = AdoExecution.ExecuteProcedureReturn(keyValuePairs, "SP_Contact");
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SendMail(string Destination, string Source, string BodyText, string Subject = "")
        {
            try
            {

                string msg = tm.send_click(Destination, Source, BodyText, Subject);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
