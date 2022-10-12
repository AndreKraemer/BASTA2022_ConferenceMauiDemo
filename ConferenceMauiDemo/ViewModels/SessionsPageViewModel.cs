using ConferenceMauiDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceMauiDemo.Models;
using ConferenceMauiDemo.Views;

namespace ConferenceMauiDemo.ViewModels
{
    public class SessionsPageViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;

        public Command<Session> NavigateToDetailsCommand { get; }

        private readonly ObservableCollection<Session> _sessions = new ObservableCollection<Session>();

        public SessionsPageViewModel(IDataService dataService)
        {
            _dataService = dataService;
            NavigateToDetailsCommand = new Command<Session>(NavigateToDetailsPage);
        }

        private void NavigateToDetailsPage(Session session)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Session", session }
            };
            Shell.Current.GoToAsync($"{nameof(SessionDetailPage)}", navigationParameter);
        }

        public ObservableCollection<Session> Sessions => _sessions;

        public async Task Initialize()
        {
            _sessions.Clear();
            var sessions = await _dataService.GetSessionsAsync();
            foreach(var session in sessions)
            {
                _sessions.Add(session);
            }
        }
    }
}
