using LotusSimulator.Contract.MessageIn;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.GUIComponents.Popups
{
    public class MulliganPopup
    {
        private TaskCompletionSource<MulliganOfferResultDto> _taskCompletionSource = new TaskCompletionSource<MulliganOfferResultDto>();
        private Window _window = new Window();

        public Task<MulliganOfferResultDto> OpenAsync()
        {
            _window = new Window();
            _window.Title = "Mulligan ?";
            _window.Left = 500;
            _window.Top = 500;

            var grid = new Grid();
            grid.ColumnsProportions.Add(new Proportion());

            var yesLabel = new Label();
            yesLabel.Text = "Yes";
            var yesButton = new Button();
            yesButton.Content = yesLabel;
            yesButton.Click += YesButton_Click;
            Grid.SetColumn(yesButton, 0);

            var noLabel = new Label();
            noLabel.Text = "No";
            var noButton = new Button();
            noButton.Content = noLabel;
            noButton.Click += NoButton_Click;
            Grid.SetColumn(noButton, 1);

            grid.Widgets.Add(yesButton);
            grid.Widgets.Add(noButton);

            _window.Content = grid;
            _window.ShowModal(GlobalInstances.Desktop);

            return _taskCompletionSource.Task;
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            _window.Close();
            _taskCompletionSource.SetResult(new MulliganOfferResultDto
            {
                IsMulligan = false
            });
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            _window.Close();
            _taskCompletionSource.SetResult(new MulliganOfferResultDto
            {
                IsMulligan = true
            });
        }
    }
}
