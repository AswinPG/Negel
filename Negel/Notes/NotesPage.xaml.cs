using Negel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Negel.Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage(Content content)
        {
            InitializeComponent();
            TitleLabel.Text = content.Heading;
            DetailLabel.Text = content.Summary;
        }
    }
}