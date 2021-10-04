using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Services
{
    public interface ILoggerService
    {
        public void Write(string message);
    }
}
