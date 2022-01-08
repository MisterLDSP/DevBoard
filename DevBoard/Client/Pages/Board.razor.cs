using DevBoard.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DevBoard.Client.Pages
{
    public partial class Board
    {
        private IEnumerable<Work> Works { get; set; }
        private Work Work { get; set; } = new Work();
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            //Works = Work.GetWorks(); // Старый способ получения работ.
            //Work work = new Work()
            //{
            //    Start = new DateTime(2021, 12, 11, 17, 5, 0),
            //    Duration = 2,
            //    Name = "DevBoard",
            //    Note = "Тестовое описание."
            //};
            //await httpClient.PostAsJsonAsync<Work>("api/Works", work);
            Works = await HttpClient.GetFromJsonAsync<IEnumerable<Work>>("api/Works");
            StateHasChanged();
        }

        public async Task Add()
        {
            Work.Start = DateTime.Now;
            await HttpClient.PostAsJsonAsync<Work>("api/Works", Work);
            await Refresh();
        }

        
        public async Task Play(int id)
        {
            NavigationManager.NavigateTo($"/playwork/{id}");
        }

        async Task Refresh()
        {
            Works = await HttpClient.GetFromJsonAsync<IEnumerable<Work>>("api/Works");
            Work.Name = String.Empty;
            StateHasChanged();
        }
    }
}
