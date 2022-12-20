using System.Collections;
using System.ComponentModel;
using Chimitheque_Mobile_App.View.Utils;
using Chimitheque_Mobile_App.ViewModel;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel;
using Newtonsoft.Json;

namespace Chimitheque_Mobile_App.View;


public partial class RecapitulatifsTransaction : ContentPage
{
    private readonly ProgressArc _progressArc;
    private DateTime _startTime;
    private readonly int _duration = 25;
    private double _progress;
    private CancellationTokenSource _cancellationTokenSource = new();

    public IDictionary<Product_Storage_LocationViewModel, double> Donnes { set; get; }

 
    public RecapitulatifsTransaction(RecapitulatifViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _progressArc = new ProgressArc();
        Start_Clock();
    }


    public RecapitulatifsTransaction( )
    {
        InitializeComponent();
        _progressArc = new ProgressArc();
        Start_Clock();
    }



    void Valider_btn_Clicked(System.Object sender, System.EventArgs e)
    {
        
    }


    private void Quit_Click(object sender, EventArgs e)
    {

        Navigation.PopAsync();
    }


    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
        
        
    //}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        ProgressButton.Text = "25"; // 
        ProgressView.Drawable = _progressArc;
    }

    // 
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

    // 
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

                ((RecapitulatifViewModel)(BindingContext)).ValiderTransAsync();
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

 