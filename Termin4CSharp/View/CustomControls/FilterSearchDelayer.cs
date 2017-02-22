using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Termin4CSharp.Model;

namespace Termin4CSharp.View.CustomControls {
    class FilterSearchDelayer {
        
        private Stopwatch stopwatch = new Stopwatch();
        private long lastSearchInMillis = -1;
        private readonly long MS_DELAY_BEFORE_SEARCH = 1000;
        private readonly int SLEEP_TIME_BETWEEN_CHECKS = 250;

        private delegate List<Room> FindFilteredRoomsDelegate(List<string> buildingNames, List<string> roomIDs, List<string> resourceNames, string freeText = null, int minCapacity = 0);

        public FilterSearchDelayer(Delegate filterMethod) {
        }

         public void ResetCounterAndUpdateFilterValues() {
            lastSearchInMillis = stopwatch.ElapsedMilliseconds;     
        }

        public void ExecuteFilterChange() {
            while (stopwatch.ElapsedMilliseconds - lastSearchInMillis <= MS_DELAY_BEFORE_SEARCH)
               Thread.Sleep(SLEEP_TIME_BETWEEN_CHECKS);
            //perform method
        }

    }
}
