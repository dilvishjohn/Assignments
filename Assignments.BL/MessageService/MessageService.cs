using System.Collections.Generic;
using System.Linq;

namespace Assignments.BL
{
    public class MessageService : IMessageService
    {
        private IList<string> messages = new List<string>();
        public IEnumerable<string> GetAllMessages()
        {
            return messages.ToList();
        }

        public string GetLastMessage()
        {
            return messages.Last();
        }

        public void SendMessage(string message)
        {
            messages.Add(message);
        }
    }
}
