using MauiPref2.Models;

namespace MauiPref2.Services;

public interface ITopicPreferencesService
{
    TopicPreferences Load();

    void Save(TopicPreferences preferences);
}