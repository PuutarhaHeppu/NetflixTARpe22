using NetflexTARpe22.Services;

namespace NetflexTARpe22.Pages;

public partial class MainPage : ContentPage
{
	int count = 0;
	public MainPage(TmdbService tmdbService)
	{
		InitializeComponent();
		_tmdbService = TmdbService;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var trending = await _tmdbService.GetTrendingAsync();
	}


}