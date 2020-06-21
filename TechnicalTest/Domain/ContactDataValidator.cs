using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TechnicalTest.Domain
{
    public class ContactDataValidator
    {
        public ContactDataValidator()
        {

        }

        public bool Validate(ContactData contactData)
        {
            if (contactData == null)
                return false;

            bool isEnum = Enum.TryParse(contactData.Type, out ContactDataTypes type);

            if (!isEnum)
                return isEnum;

            switch (type)
            {
                case ContactDataTypes.EMAIL:
                    try
                    {
                        MailAddress m = new MailAddress(contactData.Value);
                        return true;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                case ContactDataTypes.GSM:
                    return true;
            }

            return false;
        }
    }
}
