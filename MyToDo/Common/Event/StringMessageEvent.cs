using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDo.Common.Event
{
    /// <summary>
    /// 事件聚合器
    /// </summary>
   public class StringMessageEvent: PubSubEvent<string>
    {
    }
}
