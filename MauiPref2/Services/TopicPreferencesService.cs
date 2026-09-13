using System.Text.Json;
using MauiPref2.Models;
using Microsoft.Maui.Storage;

namespace MauiPref2.Services;

public class TopicPreferencesService : ITopicPreferencesService
{
    private const string PreferencesKey = "notification_topics";
    private readonly IPreferences _preferences;

    public TopicPreferencesService(IPreferences preferences)
    {
        _preferences = preferences;
    }

    public TopicPreferences Load()
    {
        var raw = _preferences.Get(PreferencesKey, string.Empty);
        if (string.IsNullOrWhiteSpace(raw))
        {
            return new TopicPreferences();
        }

        try
        {
            return JsonSerializer.Deserialize<TopicPreferences>(raw) ?? new TopicPreferences();
        }
        catch (JsonException)
        {
            return new TopicPreferences();
        }
    }

    public void Save(TopicPreferences preferences)
    {
        _preferences.Set(PreferencesKey, JsonSerializer.Serialize(preferences));
    }
}