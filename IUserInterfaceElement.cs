using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace library_system
{
    interface IUserInterfaceElement
    {
        void Display();
        //Moved into IUpdateable as its inclusion here violated the Interface Segregation principle
        //void Update();
    }
}
