using System;

namespace Practice_3_4
{
	class Employee : IComparable<Employee>
    {
        private string lastname;
        private string firstname;
        private string department;
        private double working_time;
        private double payment_per_hour;


        public Employee(string ln, string fn, string dep, double wt, double p_per_h)
        {
            lastname = ln;
            firstname = fn;
            department = dep;
            working_time = wt;
            payment_per_hour = p_per_h;
        }


        public string Info()
        {
            string s = lastname + ' ' + firstname + ' ' + department 
                        + ' ' + working_time + ' ' + payment_per_hour;
            return s;
        }


        public string getLastName()
        {
            return lastname;
        }


        public string getFullName()
        {
            return lastname + " " + firstname;
        }


        public int CompareTo(Employee obj)
        {
            int result = lastname.CompareTo(obj.lastname);
            if (result == 0)
                result = firstname.CompareTo(obj.firstname);

            return result;
        }
    }
}
