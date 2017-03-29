using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Discovery;
using Sample.Models;

namespace Sample.Dao
{
    public class AccountDao
    {
        private static CrmServiceClient crmSvc;
        private Guid _accid;
        public AccountDao()
        {
            crmSvc = new CrmServiceClient(ConfigurationManager.AppSettings["CRMOnline"]);
        }
        public Dictionary<string, object> GetByGuid(string id)
        {
            try
            {
                //Verify that u r connected
                if (crmSvc != null && crmSvc.IsReady)
                {

                    //Display the CRM version number and org name that u r connected to
                    Guid guid = new Guid(id);
                    Dictionary<string, object> data = crmSvc.GetEntityDataById("account", guid, null).Where(p =>p.Key== "accountid" || p.Key == "name" || p.Key == "description" || p.Key == "telephone1" || p.Key == "numberofemployees" || p.Key == "address1_line1" || p.Key == "address1_line2" || p.Key == "address1_city" || p.Key == "address1_postalcode").ToDictionary(p => p.Key, p => p.Value);
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                Dictionary<string, object> err = new Dictionary<string, object>();
                err.Add("error", ex.Message);
                return err;
            }
        }
        public List<Dictionary<string, object>> GetAll()
        {
            try
            {
                if (crmSvc != null && crmSvc.IsReady)
                {
                    string fetchXML =
                        @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' returntotalrecordcount='true' >
                            <entity name='account'>
                                <attribute name='accountid' />
                                <attribute name='name' />
                                <attribute name='telephone1' />
                                <attribute name='numberofemployees' />
                                <attribute name='description' />
<attribute name='address1_line1' />
<attribute name='address1_line2' />
<attribute name='address1_city' />
<attribute name='address1_postalcode' />
                            </entity>
                          </fetch>";
                    var queryserch = crmSvc.GetEntityDataByFetchSearch(fetchXML);
                    List<Dictionary<string, object>> listobj = queryserch.Values.ToList();
                    return listobj;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Create(AccountModel model)
        {
            //Instaniate an acount object
            Entity account = new Entity("account");
            account["name"] = model.name;
            account["description"] = model.description;
            account["telephone1"] = model.phone;
            account["numberofemployees"] = model.numberemp;
            account["address1_line1"] = model.str1;
            account["address1_line2"] = model.str2;
            account["address1_city"] = model.city;
            account["address1_postalcode"] = model.zipcode;
            _accid = crmSvc.Create(account);
        }
        public void Update(string guid, AccountModel model)
        {
            Guid id = new Guid(guid);
            Entity account = new Entity("account");
            ColumnSet attributes = new ColumnSet(new string[] { "name", "ownerid" });
            account = crmSvc.Retrieve(account.LogicalName, id, attributes);
            account["name"] = model.name;
            account["description"] = model.description;
            account["telephone1"] = model.phone;
            account["numberofemployees"] = model.numberemp;
            account["address1_line1"] = model.str1;
            account["address1_line2"] = model.str2;
            account["address1_city"] = model.city;
            account["address1_postalcode"] = model.zipcode;
            crmSvc.Update(account);
        }
        public List<Dictionary<string, object>> SearchByCategory(string cate, string attr, string value)
        {
            try
            {
                List<Dictionary<string, object>> filteresult = new List<Dictionary<string, object>>();
                if (cate == "string:Contains Data")
                {
                    foreach(var item in new AccountDao().GetAll())
                    {
                        if (item.Keys.Contains(value))
                        {
                             filteresult.Add(item);
                        }
                    }
                }
                else if (cate == "string:Equals")
                {
                    foreach (var item in new AccountDao().GetAll())
                    {
                        if (item.Keys.Contains(attr) && item.Values.Contains(value))
                        {
                            filteresult.Add(item);
                            return filteresult;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
//note: optionsetvalue and referencentity