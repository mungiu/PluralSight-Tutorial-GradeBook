using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSGrades
{
    // puts together args: "existingname" and "newname" to be passed as one object
    // : - specifies an inheritance
    // NameChangedEventArgs inherits from EventArgs all its members/methods
    // The name of custom event data class should end with "...EventArgs"
    public class NameChangedEventArgs : EventArgs
    {
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
