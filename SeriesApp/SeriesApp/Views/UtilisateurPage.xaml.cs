using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SeriesApp.Models;
using SeriesApp.Services;
using SeriesApp.ViewModels;

namespace SeriesApp.Views;

public sealed partial class UtilisateurPage : Page
{
    public UtilisateurViewModel ViewModel
    {
        get;
    }

    WSService wsService = new();

    public UtilisateurPage()
    {
        ViewModel = App.GetService<UtilisateurViewModel>();
        InitializeComponent();
    }

    public async void BtnSearch_Click(object sender, RoutedEventArgs e)
    {
        if (boxMailSearch.Text is null)
        {
            return;
        }

        Utilisateur user = await wsService.GetByStringAsync("Utilisateurs", boxMailSearch.Text);
        if (user is null)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Erreur",
                Content = "Aucun utilisateur n'a été trouvé ",
                CloseButtonText = "OK"
            };
            ContentDialogResult resultDialog = await contentDialog.ShowAsync();
            return;
        }
        boxNom.Text = user.Nom;
        boxPrenom.Text = user.Prenom;
        boxMobile.Text = user.Mobile;
        boxMail.Text = user.Mail;
        boxPassword.Password = user.Pwd;
        boxRue.Text = user.Rue;
        boxCodePostal.Text = user.CodePostal;
        boxVille.Text = user.Ville;
        boxPays.Text = user.Pays;
        return;
    }
}
