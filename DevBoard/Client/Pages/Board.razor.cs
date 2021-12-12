using DevBoard.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoard.Client.Pages
{
    public partial class Board
    {
        private IEnumerable<Work> Works { get; set; }

        protected override void OnInitialized()
        {
            Works = Work.GetWorks();
        }

    }
}
