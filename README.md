# MauiPref2 — Case Notification Topic Preferences

A .NET 10 MAUI app that displays a user preference screen for subscribing to notification
topics. Each topic has a toggle button (MAUI `Switch`) that is persisted to device storage
via `Microsoft.Maui.Storage.IPreferences` (JSON serialized through `TopicPreferencesService`).

## Features

- **Topics screen** (`Views/TopicPreferencesPage.xaml`): toggle buttons to subscribe to the
  **Case Update** and **Case Complete** topics.
- **Persistence**: every toggle change is saved immediately using `IPreferences` through
  `Services/TopicPreferencesService`, so choices survive app restarts.
- **MVVM**: `ViewModels/TopicPreferencesViewModel` holds the toggle state and is resolved from
  the DI container registered in `MauiProgram.cs`.

## Architecture

```
Models/NotificationTopic.cs        Enum of subscribable topics (CaseUpdate, CaseComplete)
Models/TopicPreferences.cs         Serializable subscription state
Services/ITopicPreferencesService  Abstraction over preference storage
Services/TopicPreferencesService   JSON (de)serialization via IPreferences
ViewModels/TopicPreferencesViewModel  Toggle bindings, persists on change
Views/TopicPreferencesPage.xaml    The preference screen
```

## Build

```bash
# Install the MAUI workload (on Linux, android-only)
dotnet workload install maui-android

# Build for Android
dotnet build -f net10.0-android
```

On Linux, the Android SDK is required. The build picks it up via the `ANDROID_HOME`
environment variable (or pass `-p:AndroidSdkDirectory=<path>`).