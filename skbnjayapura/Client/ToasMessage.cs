using BlazorBootstrap;

namespace skbnjayapura.Client
{
    public static class ToasMessage
    {
        public static List<ToastMessage> Messages { get; set; } = new List<ToastMessage>();

        public static Task ShowMessage(string message, ToastType type, string title = "Info", string helpeText = "")
        {
            Messages.Add(new ToastMessage
            {
                Type = type,
                Title = title,
                HelpText = helpeText,
                Message = message,
            });
            return Task.CompletedTask;
        }

    }
}
