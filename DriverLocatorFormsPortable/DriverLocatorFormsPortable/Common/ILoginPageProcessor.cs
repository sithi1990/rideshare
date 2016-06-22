using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLocatorFormsPortable.Common
{
    public interface ILoginPageProcessor
    {
        void MoveToMainPage();
        void MoveToCreateUserPage();
        void MoveToSignUpPage();
    }
}
