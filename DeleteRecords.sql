--delete  from AspNetRoles;
--delete  from AspNetUserLogins;
--delete  from tblAppointmentStatus;
--delete  from tblAppointmentTypes;
--delete  from tblCandidateStatus;
--delete  from tblJobVacanciesStatus;
--delete  from tblMSPQuestions;
--delete  from tblMSPRequiredDocument;
--delete  from tblMSPSpendCategory;
--delete  from tblMSPTimeGroup;
--delete  from tblTimesheetStatus;
--delete  from tblFileTypes;
--delete  from tblMSPVacancieTypes;
delete  from tblCandidateContacts;
delete  from tblCandidateFiles;
delete  from tblCandidateIndustries;
delete  from tblCandidateSkills;
delete  from tblCandidateSubmissionAppointmentSlots;
delete  from tblCandidateSubmissionAppointmentUserComments;
delete  from tblCandidateSubmissionAppointmentUsers;
delete  from tblCandidateSubmissionComments;
delete  from tblCandidateSubmissionDocumentResponses;
delete  from tblCandidateSubmissionSpend;
delete  from tblCandidateSubmissionSpendFiles;
delete  from tblCandidateSubmissionsQuestionsResponses;
delete  from tblCandidateTimesheetCategoriesHours;
delete  from tblCandidateTimesheetHours;
delete  from tblCandidateTimesheets;
delete  from tblCommentUsers;
delete  from tblContacts;
delete  from tblCustomerLocationBranches;
delete  from tblCustomerUsers;
delete  from tblFiles;
delete  from tblMSPCustomers;
delete  from tblMSPLocationBranches;
delete  from tblMSPPayPeriods;
delete  from tblMSPTimeCategories;
delete  from tblMSPTimeGroupCategories;
delete  from tblMSPUsers where UserID !='afcf8230-7878-4e1d-a550-532fd10769ae';
delete  from tblSupplierCandidates;
delete  from tblSupplierLocationBranches;
delete  from tblSupplierUsers;
delete  from tblUserLocationBranches;
delete  from tblUserProfile where UserID !='afcf8230-7878-4e1d-a550-532fd10769ae';
delete  from tblVacancieSkills;
delete  from tblVacanciesQuestions;
delete  from tblVacanciesRequiredDocuments;
delete  from tblVacancyComments;
delete  from tblVacancyFiles;
delete  from tblVacancyLocations;
delete  from tblVacancySuppliers;
delete  from tblBranches;
delete  from tblCandidatePlacements;
delete  from tblCandidateSubmissionAppointments;
delete  from tblComments;
delete  from tblIndustrySkills;
delete  from tblLocations;
delete  from tblSupplier;
delete  from AspNetUsers where Id !='afcf8230-7878-4e1d-a550-532fd10769ae';
delete  from tblCandidateSubmission;
delete  from tblCandidates;
delete  from tblIndustries;
delete  from tblVacancies;
delete  from tblCustomers;
delete  from tblMSPDetails where ID !=1;
update tblUserProfile set StateID=1,CountryID=3;
update tblMSPDetails set StateID=1,CountryID=3;
delete  from tblCountryStates where ID !=1;
delete  from tblCountries where ID !=3;
delete  from AspNetRoleGroupRoles where RoleGroupId in(select Id from AspNetRoleGroups where Name !='Admin');
delete  from AspNetRoleGroups where Name !='Admin';
delete  from AspNetUserRoles where UserID !='afcf8230-7878-4e1d-a550-532fd10769ae';
