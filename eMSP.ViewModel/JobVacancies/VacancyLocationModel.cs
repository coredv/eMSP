﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{
    public class VacancyLocationModel
    {
        public VacancyLocationModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }
    }

    public class VacancyLocationsCreateModel : VacancyLocationModel
    {
        public VacancyLocationsCreateModel() { }
        public long locationId { get; set; }
        public string locationName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public System.DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<System.DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}