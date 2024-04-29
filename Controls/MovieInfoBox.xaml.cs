using NetflixTARpe22.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace NetflixTARpe22.Controls;

public partial class MovieInfoBox : ContentView
{
	public static readonly BindableProperty MediaProperty =
		BindableProperty.Create(nameof(Media), typeof(Media), typeof(MovieInfoBox), null);

	public event EventHandler Closed;

	public MovieInfoBox()
	{
		InitializeComponent();
		ClosedCommand = new Command(ExecuteClosedCommand);
	}
	public Media Media
	{
		get => (Media)GetValue(MovieInfoBox.MediaProperty);
		set => SetValue(MovieInfoBox.MediaProperty, value);
	}

	public ICommand ClosedCommand { get; private set; }
	private void ExecuteClosedCommand() => 
		Closed?.Invoke(this, EventArgs.Empty);
}