using NetflixTARpe22.Pages;

namespace NetflexTARpe22;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
	}
}
