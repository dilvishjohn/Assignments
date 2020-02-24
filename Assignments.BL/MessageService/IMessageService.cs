using System.Collections.Generic;

namespace Assignments.BL
{
    public interface IMessageService
    {
        void SendMessage(string message);

        IEnumerable<string> GetAllMessages();

        string GetLastMessage();
    }
}
