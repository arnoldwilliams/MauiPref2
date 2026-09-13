namespace MauiPref2.Models;

public class TopicPreferences
{
    public bool CaseUpdateSubscribed { get; set; }

    public bool CaseCompleteSubscribed { get; set; }

    public bool IsSubscribed(NotificationTopic topic) => topic switch
    {
        NotificationTopic.CaseUpdate => CaseUpdateSubscribed,
        NotificationTopic.CaseComplete => CaseCompleteSubscribed,
        _ => false
    };

    public void SetSubscription(NotificationTopic topic, bool subscribed)
    {
        switch (topic)
        {
            case NotificationTopic.CaseUpdate:
                CaseUpdateSubscribed = subscribed;
                break;
            case NotificationTopic.CaseComplete:
                CaseCompleteSubscribed = subscribed;
                break;
        }
    }
}