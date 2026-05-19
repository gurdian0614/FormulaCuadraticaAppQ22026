namespace FormulaCuadraticaAppQ22026.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class FormulaCuadraticaViewModel : ObservableObject
{
    [ObservableProperty]
    private double a; // No se puede declarar con la primera letra mayúscula

    [ObservableProperty]
    private double b;

    [ObservableProperty]
    private double c;

    [ObservableProperty]
    private double x1;

    [ObservableProperty]
    private double x2;

    [RelayCommand]
    private async Task Calcular()
    {
        try
        {
            if (A == 0)
            {
                await Application.Current!.MainPage!.DisplayAlert("ADVERTENCIA", "El coeficiente 'a' no puede ser igual a cero", "Aceptar");
            }
            else
            {
                double discrimante = Math.Pow(B, 2) - 4 * A * C;

                if (discrimante >= 0)
                {
                    X1 = (-B + Math.Sqrt(discrimante)) / (2 * A);
                    X2 = (-B - Math.Sqrt(discrimante)) / (2 * A);
                }
                else
                {
                    await Application.Current!.MainPage!.DisplayAlert("ADVERTENCIA", "No se puede calcular la raíz cuadrada con números negativos.", "Aceptar");
                }
            }
        } catch(Exception e)
        {
            await Application.Current!.MainPage!.DisplayAlert("ERROR", e.Message, "Aceptar");
        }
    }

    [RelayCommand]
    private void Limpiar()
    {
        A = 0;
        B = 0;
        C = 0;
        X1 = 0;
        X2 = 0;
    }
}