using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;


namespace MyAssignment.Classes
{
    internal class Member 
    {
        private int memberId;
        private string name;
        private int age;
        private int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Member(int memberId,string name, int age)
        {
            this.name = name;
            this.age = age;
            this.memberId = memberId;
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine("Member ID : " + MemberId);
            Console.WriteLine("Member Name : " + Name);
            Console.WriteLine("Member Age :" + Age);
           

        }
    }
}
