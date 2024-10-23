using app_desafio100dias.viewModels;
using System.ComponentModel;

namespace app_desafio100dias;

public partial class NewChallenge : ContentPage
{
    private int nDiasDesafio = 4;

    private CalendarViewModel viewModel;

    public NewChallenge()
    {
        InitializeComponent();
        viewModel = new CalendarViewModel();
        BindingContext = viewModel;

        endDate.Date = startDate.Date.AddDays(nDiasDesafio);
    }

    private void OnStartDateChanged(object sender, DateChangedEventArgs e)
    {
        endDate.Date = e.NewDate.AddDays(nDiasDesafio);
    }

    private void OnAddEventClicked(object sender, EventArgs e)
    {
        endDate.Date = startDate.Date.AddDays(nDiasDesafio);

        for (int i = 0; i < nDiasDesafio + 1; i++)
        {
            var newEvent = new EventModel
            {
                Name = eventName.Text,
                Description = eventDescription.Text,
                StartDate = startDate.Date,
                eventDate = startDate.Date.AddDays(i),
                EndDate = startDate.Date.AddDays(nDiasDesafio)
            };

            viewModel.AddEvent(newEvent);
        }

        ClearInputs();
    }

    private void ClearInputs()
    {
        eventName.Text = string.Empty;
        eventDescription.Text = string.Empty;
        startDate.Date = DateTime.Now;
        endDate.Date = DateTime.Now.AddDays(nDiasDesafio);
    }
    
}