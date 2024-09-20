using System;

namespace GUI
{
    public class LoginAttempt
    {
        public DateTime Timestamp { get; set; }
        public string Login { get; set; }
        public bool Success { get; set; }
    }
}