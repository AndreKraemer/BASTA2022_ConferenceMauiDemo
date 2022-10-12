using System.Windows.Input;
using ConferenceMauiDemo.Models;

namespace ConferenceMauiDemo.ViewModels
{
    [QueryProperty(nameof(Session), nameof(Session))]
    public class SessionDetailPageViewModel : BaseViewModel
    {
        private Session _session;

        public SessionDetailPageViewModel()
        {
            OpenTwitterCommand = new Command(OpenTwitter);
        }

        public Session Session
        {
            get => _session;
            set => SetProperty(ref _session, value);
        }

        public ICommand OpenTwitterCommand { get; }

        private void OpenTwitter()
        {
            Browser.OpenAsync(Session.Speaker.Twitter);
        }
    }
}
