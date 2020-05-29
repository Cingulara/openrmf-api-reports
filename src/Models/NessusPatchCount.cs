// Copyright (c) Cingulara LLC 2019 and Tutela LLC 2019. All rights reserved.
// Licensed under the GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007 license. See LICENSE file in the project root for full license information.

namespace openrmf_report_api.Models
{
    /// <summary>
    /// This is the class that shows the count and ummary number of items for the ACAS Nessus Patch scan of systems
    /// </summary>

    public class NessusPatchCount
    {

        public NessusPatchCount () {        }
        public int totalCriticalOpen { get; set; }
        public int totalHighOpen { get; set; }
        public int totalMediumOpen { get; set; }
        public int totalLowOpen { get; set; }
        public int totalInfoOpen { get; set; }
    }
}