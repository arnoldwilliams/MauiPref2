using MauiPref2.ViewModels;

namespace MauiPref2.Views;

public partial class TopicPreferencesPage : ContentPage
{
	public TopicPreferencesPage(TopicPreferencesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}