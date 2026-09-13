using MauiPref2.Models;
using MauiPref2.Services;

namespace MauiPref2.ViewModels;

public class TopicPreferencesViewModel : ObservableObject
{
    private readonly ITopicPreferencesService _topicPreferencesService;
    private bool _caseUpdateSubscribed;
    private bool _caseCompleteSubscribed;

    public TopicPreferencesViewModel(ITopicPreferencesService topicPreferencesService)
    {
        _topicPreferencesService = topicPreferencesService;

        var saved = _topicPreferencesService.Load();
        _caseUpdateSubscribed = saved.CaseUpdateSubscribed;
        _caseCompleteSubscribed = saved.CaseCompleteSubscribed;
    }

    public bool CaseUpdateSubscribed
    {
        get => _caseUpdateSubscribed;
        set
        {
            if (SetProperty(ref _caseUpdateSubscribed, value))
            {
                SaveSubscription(NotificationTopic.CaseUpdate, value);
            }
        }
    }

    public bool CaseCompleteSubscribed
    {
        get => _caseCompleteSubscribed;
        set
        {
            if (SetProperty(ref _caseCompleteSubscribed, value))
            {
                SaveSubscription(NotificationTopic.CaseComplete, value);
            }
        }
    }

    public TopicPreferences CurrentPreferences => new()
    {
        CaseUpdateSubscribed = CaseUpdateSubscribed,
        CaseCompleteSubscribed = CaseCompleteSubscribed
    };

    private void SaveSubscription(NotificationTopic topic, bool subscribed)
    {
        var preferences = CurrentPreferences;
        preferences.SetSubscription(topic, subscribed);
        _topicPreferencesService.Save(preferences);
    }
}