using LotusSimulator.Client.GUIComponents.Popups;
using LotusSimulator.Contract.MessageIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class ModalService
    {
        public async Task<MulliganOfferResultDto> OpenMulliganPopup()
        {
            var mulliganPopup = new MulliganPopup();
            return await mulliganPopup.OpenAsync();
        }
    }
}
