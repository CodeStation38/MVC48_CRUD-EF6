using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCEF6.Model;
using System.Globalization;

namespace MVCEF6.BL
{
    public class CustomerManager
    {
        #region Filter By Option List
        public List<string> GetCustomersByPrefColor()
        {
            var db = new MVCEF6Context();
            var prefColorQry = from d in db.Customers
                               orderby d.PrefferedColor
                               select d.PrefferedColor;

            return prefColorQry.ToList();
        }

        public List<string> GetCustomersByMainHobby()
        {
            var db = new MVCEF6Context();
            var mainHobbyQry = from d in db.Customers
                               orderby d.MainHobby
                               select d.MainHobby;
            return mainHobbyQry.ToList();
        }
        #endregion

        #region Filter By String
        //public List<Customer> GetCustomersByBirthDate(string birthDate)
        //{     
        //    if(StringIsDate(birthDate)!=null)
        //    return new List<Customer>();
        //}

        //public List<Customer> GetCustomersByNumberOfRooms(string numberOfRooms)
        //{
        //    return new List<Customer>();
        //}
        #endregion

        #region General Functions
        //GetAllCustomers
        public List<Customer> GetAllCustomers()
        {
            var db = new MVCEF6Context();
            var customersls = from m in db.Customers
                              select m;
            return customersls.ToList();
        }

        public DateTime? StringIsDate(string searchString)
        {
            var stringDate = new DateTime?();

            string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", 
                   "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", 
                   "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", 
                   "M/d/yyyy h:mm", "M/d/yyyy h:mm", 
                   "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};
            //string[] dateStrings = {"5/1/2009 6:32 PM", "05/01/2009 6:32:05 PM", 
            //            "5/1/2009 6:32:00", "05/01/2009 06:32", 
            //            "05/01/2009 06:32:00 PM", "05/01/2009 06:32:00"};
            DateTime dateValue;

            if (DateTime.TryParseExact(searchString, formats, new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
                stringDate = dateValue;
            else
                stringDate = null;

            return stringDate;
        }

        public bool StringIsNumber(string searchString)
        {
            int n;
            var isNumeric = int.TryParse(searchString, out n);

            return isNumeric;
        }
        #endregion
    }
}
