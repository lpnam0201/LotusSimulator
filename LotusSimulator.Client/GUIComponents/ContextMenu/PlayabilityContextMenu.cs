using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.GUIComponents.ContextMenu
{
    public class PlayabilityContextMenu
    {
        private List<PlayabilityDto> _playabilities;

        public PlayabilityContextMenu(List<PlayabilityDto> playabilities)
        {
            _playabilities = playabilities;
        }

        public void Show()
        {
            var verticalMenu = new VerticalMenu();

            foreach (var playability in _playabilities)
            {
                var menuItem = new MenuItem();
                menuItem.Text = playability.Text;
                menuItem.Selected += (sender, arg) =>
                {
                    PlayabilityChosen_Selected(sender, arg, playability);
                };

                verticalMenu.Items.Add(menuItem);
            }

            GlobalInstances.Desktop.ShowContextMenu(verticalMenu, GlobalInstances.Desktop.TouchPosition.Value);
        }

        private void PlayabilityChosen_Selected(object sender, EventArgs e, PlayabilityDto playability)
        {
            GlobalInstances.GameStateService.SendPlayerInputAsync(new PlayerInputDto
            {
                Playability = playability,
                GameId = GlobalInstances.GamePreparationState.GameId
            });
        }
    }
}
