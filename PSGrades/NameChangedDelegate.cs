using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSGrades
{
    // This event, passes with itself the 1st string and 2nd parameter:
    // 1st param = contain info about the event (itself)
    //      E.G. if gradebook announces "NameChanged" which is:
    //      " public event NameChangedDelegate NameChanged; "
    //      first param sends info about the event (itself)
    // 2nd param = contains all the info about this event 
    // (therefore we define it in new class that will hold all the arguments)

    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
