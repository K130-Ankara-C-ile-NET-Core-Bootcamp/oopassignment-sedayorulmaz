using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.AllInterfaces
{
    public interface ICommand<T> where T:class
    {
        void ExecuteCommand(T commandObject);
    }
}
