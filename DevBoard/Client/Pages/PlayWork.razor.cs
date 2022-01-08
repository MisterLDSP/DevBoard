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
    public partial class PlayWork
    {
        [Parameter] public string WorkId { get; set; }
        [Inject] HttpClient HttpClient { get; set; }
        private Work Work { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Work = await HttpClient.GetFromJsonAsync<Work>($"api/works/{WorkId}");
            StateHasChanged();
        }
    }
}
