// Copyright (c) Cingulara LLC 2019 and Tutela LLC 2019. All rights reserved.
// Licensed under the GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007 license. See LICENSE file in the project root for full license information.

using openrmf_report_api.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Microsoft.Extensions.Options;

namespace openrmf_report_api.Data {
    public class ReportRepository : IReportRepository
    {
        private readonly ReportContext _context = null;

        public ReportRepository(IOptions<Settings> settings)
        {
            _context = new ReportContext(settings);
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        // query after Id or InternalId (BSonId value)
        //
        public async Task<IEnumerable<NessusPatchData>> GetPatchDataBySystem(string id)
        {
                return await _context.ACASScanReports.Find(data => data.systemGroupId == id).ToListAsync();
        }
        public async Task<IEnumerable<VulnerabilityReport>> GetChecklistVulnerabilityData(string systemGroupId, string vulnid){
                return await _context.VulnerabilityReports.Find(v => v.vulnid == vulnid && v.systemGroupId == systemGroupId).ToListAsync();
        }

        // check that the database is responding and it returns at least one collection name
        public bool HealthStatus(){
            var result = _context.ACASScanReports.Database.ListCollectionNamesAsync().GetAwaiter().GetResult().FirstOrDefault();
            if (!string.IsNullOrEmpty(result)) // we are good to go
                return true;
            return false;
        }
    }
}