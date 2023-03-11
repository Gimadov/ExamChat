using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDemoExam.DataBaseModel;

namespace ChatDemoExam.Classes
{
    internal class ConnectingClass
    {
        public static ChatDemoEntities connect = new ChatDemoEntities();
    }
}
