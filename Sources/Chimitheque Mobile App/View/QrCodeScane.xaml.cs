using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Chimitheque_Mobile_App.View;

public partial class QrCodeScane : ContentPage
{
	public QrCodeScane()
	{
		InitializeComponent();
        //label.Text = Preferences.Get("token", "");

        // Option de lecture des codes sur tous lesformats (dmensions)
        barcodeView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true
        };
    }

    // Fonction de traitement de lecture des codes qrCode/barcode 
    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var data = e.Results.FirstOrDefault();
      
        if (data is not null)
        {
           Console.WriteLine(data.ToString());
        }
    }

    // Fonction de changement de camera (Front or Back)
    void SwitchCameraButton_Clicked(object sender, EventArgs e)
    {
        barcodeView.CameraLocation = barcodeView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
    }


    // Fonction de torche
    void TorchButton_Clicked(object sender, EventArgs e)
    {
        barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
    }
}