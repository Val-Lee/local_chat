using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_chat_v2.__
{
    public class Msg_info
    {
        string MsgFrom;
        string MsgTo;
        string CurTime;
        string Message;


        public string _MsgFrom
        {
            get { return MsgFrom; }
            set { MsgFrom = value; }
        }
        public string _MsgTo
        {
            get { return MsgTo; }
            set { MsgTo = value; }
        }
        public string _CurTime
        {
            get { return CurTime; }
            set { CurTime = value; }
        }
        public string _Message
        {
            get { return Message; }
            set { Message = value; }
        }

        public override string ToString()
        {
            return CurTime+ ": " +Message+ " From: " +MsgFrom+ " To: " +MsgTo;
        }


    }
}
