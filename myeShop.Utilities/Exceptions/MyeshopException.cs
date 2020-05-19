using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.Utilities.Exceptions
{
    public class MyeshopException:Exception
    {
        public MyeshopException()
        {
        }

        public MyeshopException(string message)
            : base(message)
        {
        }

        public MyeshopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
