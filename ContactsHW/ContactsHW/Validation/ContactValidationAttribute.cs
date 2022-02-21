using ContactsHW.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactsHW.Validation
{
    public class ContactValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Contact contact = value as Contact;

            return true;
        }
    }
}
