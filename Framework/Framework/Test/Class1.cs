using Framework.Global;
using Framework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    public class Class1
    {
        [TestFixture]
        [Category("Sprint_1")]
        class Sprint_1 : Base
        {

            [Test]
            public void Test_001()
            {
                Register objRegister = new Register();
                objRegister.ValidateFirstName();
            }


        }

    }
}
