namespace WideBotApi.Models
{
    public class FacebookGC
    {
        internal int Id { get; set;}
        internal string Email { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string Image_Uri{ get; set; }
        
        public DefaultAction DefaultAction { get; set; }
        public List<Button> Buttons { get; set; }

        
    }

    public class DefaultAction
    {
        private string email;
        public DefaultAction(string _email)
        {
            this.email = _email;
            this.Url = $"https://mail.google.com/main/u/0/?fs=1&tf=cm&to={email}&su=Hello&body=Send%20Email";
        }
        public string Type { get; set; } = "web_url";
        public string Url { get;}
        public string Webview_Height_Ratio { get; set; } = "tall";

    }

    public class Button
    {
        private string email;
        public Button(string _email)
        {
            this.email = _email;
            this.Url = $"https://mail.google.com/main/u/0/?fs=1&tf=cm&to={email}&su=Hello&body=Send%20Email";
        }
        public string Type { get; set; } = "web_url";
        public string Url { get; set; }
        public string Title { get; set; } = "Send Email";
    }
}
