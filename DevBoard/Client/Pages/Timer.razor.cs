using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoard.Client.Pages
{
    public partial class Timer
    {
        private bool IsPlay { get; set; } = false;
        private DateTime Start { get; set; }
        private DateTime Stop { get; set; }
        private System.Threading.Timer _timer;
        private double elapsedtime = 0;

        protected override async Task OnInitializedAsync()
        {
            StartTime();
        }

        public void StartTime()
        {
            Start = DateTime.Now;
            IsPlay = true;
            _timer = new System.Threading.Timer(async _ =>
            {
                elapsedtime = ElapsedTimeSecs();
                await InvokeAsync(StateHasChanged);
            }, null, 0, 1000);
        }
        public void StopTime()
        {
            Stop = DateTime.Now;
            _timer.Dispose();
            IsPlay = false;
        }
        public double ElapsedTimeSecs()
        {
            TimeSpan interval;
            if (IsPlay)
                interval = DateTime.Now - Start;
            else
                interval = Stop - Start;
            return interval.TotalSeconds;
        }
    }
}
