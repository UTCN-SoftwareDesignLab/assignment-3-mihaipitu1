using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Models
{
    public class Patient
    {
        private long id;
        private string name;
        private string idCardNo;
        private string address;
        private DateTime birthDate;


        public long GetId()
        {
            return id;
        }
        public void SetId(long id)
        {
            this.id = id;
        }
        public long Id
        {
            get { return GetId(); }
            set { SetId(value); }
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return GetName(); }
            set { SetName(value); }
        }

        public string GetIdCardNo()
        {
            return idCardNo;
        }
        public void SetIdCardNo(string idCardNo)
        {
            this.idCardNo = idCardNo;
        }
        public string IdCardNo
        {
            get { return GetIdCardNo(); }
            set { SetIdCardNo(value); }
        }

        public string GetAddress()
        {
            return address;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }
        public string Address
        {
            get { return GetAddress(); }
            set { SetAddress(value); }
        }

        public DateTime GetBirthDate()
        {
            return birthDate;
        }
        public void SetBirthDate(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }
        public DateTime BirthDate
        {
            get { return GetBirthDate(); }
            set { SetBirthDate(value); }
        }

    }
}
