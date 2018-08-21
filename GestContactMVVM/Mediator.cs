using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContactMVVM
{
    public static class Mediator<TSender>
    {
        private static Action<TSender, string> _Broadcast;
                
        public static void Register(Action<TSender, string> Method)
        {
            _Broadcast += Method;
        }

        public static void Unregister(Action<TSender, string> Method)
        {
            _Broadcast -= Method;
        }

        public static void Send(TSender sender, string Info)
        {
            if(_Broadcast != null)
            {
                _Broadcast(sender, Info);
            }
        }
    }
}
