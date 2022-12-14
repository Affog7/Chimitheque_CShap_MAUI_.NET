using System.Collections;
using System.ComponentModel;
using Chimitheque_Mobile_App.View.Utils;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel;
using Newtonsoft.Json;

namespace Chimitheque_Mobile_App.View;


public partial class RecapitulatifsTransaction : ContentPage, IQueryAttributable, INotifyPropertyChanged
{
    private readonly ProgressArc _progressArc;
    private DateTime _startTime;
    private readonly int _duration = 25;
    private double _progress;
    private CancellationTokenSource _cancellationTokenSource = new();

    public IDictionary<Product_Storage_LocationViewModel, double> Donnes { set; get; }  

    public RecapitulatifsTransaction(IDictionary<Product_Storage_LocationViewModel, double> choixProduits)
	{

         Donnes = choixProduits;

		InitializeComponent();
		BindingContext = this;

	}

    public RecapitulatifsTransaction()
    {
        InitializeComponent();
        BindingContext = this;
        _progressArc = new ProgressArc();
        Start_Clock();
    }

    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        
        Donnes = query["Donnes"] as Dictionary<Product_Storage_LocationViewModel, double>;

        OnPropertyChanged(nameof(Donnes));
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        ProgressButton.Text = "25"; // Play icon - workaround because setting it in xaml broke the build for some reason
        ProgressView.Drawable = _progressArc;
    }

    // Handle button click events
    private void StartButton_OnClicked(object sender, EventArgs e)
    {
        Start_Clock();
    }

    private void Start_Clock()
    {
        _startTime = DateTime.Now;
        _cancellationTokenSource = new CancellationTokenSource();
        UpdateArc();
    }

    // Cancel the update loop
    private void ResetButton_OnClicked(object sender, EventArgs e)
    {
        _cancellationTokenSource.Cancel();
        UpdateArc();
    }

    private async void UpdateArc()
    {
        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        {
            TimeSpan elapsedTime = DateTime.Now - _startTime;
            int secondsRemaining = (int)(_duration - elapsedTime.TotalSeconds);

            ProgressButton.Text = $"{secondsRemaining} s";

            _progress = Math.Ceiling(elapsedTime.TotalSeconds);
            _progress %= _duration;
            _progressArc.Progress = _progress / _duration;
            ProgressView.Invalidate();

            if (secondsRemaining == 0)
            {
                _cancellationTokenSource.Cancel();
                return;
            }

            await Task.Delay(500);
        }

        ResetView();
    }

    private void ResetView()
    {
        _progress = 0;
        _progressArc.Progress = 100;
        ProgressView.Invalidate();
        ProgressButton.Text = "25 s";
    }
}

 