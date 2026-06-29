using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Day4Task.ViewModels;

public class ProfileViewModel : INotifyPropertyChanged
{
    private ImageSource _profileImage;

    public ImageSource ProfileImage
    {
        get => _profileImage;
        set { _profileImage = value; OnPropertyChanged(); }
    }

    public ICommand TakePhotoCommand { get; }

    public ProfileViewModel()
    {
        _profileImage = ImageSource.FromFile("profile_img.svg");
        TakePhotoCommand = new Command(async () => await TakePhotoAsync());
    }

    private async Task TakePhotoAsync()
    {
        try
        {
            if (!MediaPicker.Default.IsCaptureSupported)
            {
                await Shell.Current.DisplayAlertAsync("Not Supported", "Camera is not available on this device.", "OK");
                return;
            }

            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                await Shell.Current.DisplayAlertAsync("Permission Denied", "Camera permission is required.", "OK");
                return;
            }

            var photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                ProfileImage = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Error", ex.Message, "OK");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}