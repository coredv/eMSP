﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.Data.DataServices.Company;
using eMSP.ViewModel.LocationBranch;
using eMSP.Data.Extensions;
using eMSP.DataModel;
using eMSP.ViewModel.JobVacancies;
using System.Configuration;
using eMSP.ViewModel.MSP;
using eMSP.Data.DataServices.Comments;
using eMSP.ViewModel.Comments;

namespace eMSP.Data.DataServices.JobVacancies
{
    public class VacanciesManager
    {
        #region Initialization

        private bool IsDisposed = false;
        CommentsManager _commentsManager = new CommentsManager();

        public VacanciesManager()
        {

        }

        #endregion

        #region Get

        public async Task<VacancyCreateModel> GetVacancy(long Id)
        {
            try
            {
                VacancyCreateModel model = null;
                tblVacancy data = await Task.Run(() => ManageVacancy.GetVacancyDetails(Id));
                model = data.ConvertToVacancyCreateModel();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<VacancyCreateModel>> GetAllVacancies(CompanyModel model)
        {
            try
            {
                List<VacancyCreateModel> data = null;

                List<tblVacancy> res = await Task.Run(() => ManageVacancy.GetAllVacancies(model));

                data = res.Select(x => x.ConvertToVacancyCreateModel()).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<CommentModel>> GetVacancyComments(long id)
        {
            try
            {
                List<CommentModel> data = null;

                tblVacancy res = await Task.Run(() => ManageVacancy.GetVacancyComments(id));

                data = res.tblVacancyComments?.Select(a => a.tblComment?.ConvertToComment()).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<List<VacancySkillsCreateModel>> GetVacancySkills(long Id)
        //{
        //    try
        //    {
        //        List<VacancySkillsCreateModel> data = null;

        //        List<tblVacancieSkill> res = await Task.Run(() => ManageVacancySkills.GetVacancySkills(Id));

        //        data = res.Select(x => x.ConvertToVacancySkill()).ToList();

        //        return data;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<List<VacancyLocationsCreateModel>> GetVacancyLocations(long Id)
        //{
        //    try
        //    {
        //        List<VacancyLocationsCreateModel> data = null;

        //        List<tblVacancyLocation> res = await Task.Run(() => ManageVacancyLocations.GetVacancyLocations(Id));

        //        data = res.Select(x => x.ConvertToVacancyLocation()).ToList();

        //        return data;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<List<VacancySuppliersCreateModel>> GetVacancySupplier(long Id)
        //{
        //    try
        //    {
        //        List<VacancySuppliersCreateModel> data = null;

        //        List<tblVacancySupplier> res = await Task.Run(() => ManageVacancySuppliers.GetVacancySuppliers(Id));

        //        data = res.Select(x => x.ConvertToVacancySupplier()).ToList();

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public async Task<List<MSPVacancieTypeCreateModel>> GetMSPVacancieType(MSPVacancieTypeCreateModel data)
        {
            try
            {
                long Id = data.mspId != 0 ? Convert.ToInt64(data.mspId) : 0;
                long id = Convert.ToInt64(ConfigurationManager.AppSettings["MSP_ID"]);
                Id = Id != 0 ? Id : id;

                List<MSPVacancieTypeCreateModel> model = null;
                List<tblMSPVacancieType> dataVT = null;


                dataVT = await Task.Run(() => ManageMSPVacancieType.GetMSPVacancieTypes(Id));


                model = dataVT.Select(a => a.ConvertToMSPVacancieType()).ToList();

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<VacanciesStatus>> GetVacancyStatus()
        {
            try
            {
                List<tblJobVacanciesStatu> model = await Task.Run(() => ManageJobVacanciesStatus.GetJobVacanciesStatuses());

                return model.Select(x => x.ConvertToVacanciesStatus()).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        #endregion

        #region Insert

        public async Task<VacancyCreateModel> CreateVacancy(VacancyCreateModel data)
        {
            try
            {
                VacancyCreateModel model = null;
                VacancyCreateModel res = await Task.Run(() => ManageVacancy.Insert(data));

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CommentModel> CommentVacancy(VacancyCommentCreateModel data)
        {
            try
            {
                tblComment resComment = await Task.Run(() => ManageComments.InsertComment(data.comment.ConvertTotblComment()));
                data.vacancyComment.commentId = resComment.ID;

                tblVacancyComment res = await Task.Run(() => ManageVacancyComments.CommentVacancy(data.vacancyComment.ConvertTotblVacancyComment()));
                data.vacancyComment.Id = res.ID;

                data.commentUser.commentId = resComment.ID;                
                tblCommentUser resCommentUser= await Task.Run(() => ManageComments.InsertCommentUser(data.commentUser.ConvertTotblCommentUser()));                

                return resComment.ConvertToComment();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MSPVacancieTypeCreateModel> CreateMSPVacancieType(MSPVacancieTypeCreateModel data)
        {
            try
            {
                long mspId = Convert.ToInt64(ConfigurationManager.AppSettings["MSP_ID"]);
                data.mspId = data.mspId != 0 ? data.mspId : mspId;
                tblMSPVacancieType dataMSPVacancieType = await Task.Run(() => ManageMSPVacancieType.InsertMSPVacancieType(data.ConvertTotblMSPVacancieType()));

                return dataMSPVacancieType.ConvertToMSPVacancieType();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion

        #region Update

        public async Task<VacancyCreateModel> UpdateVacancy(VacancyCreateModel model)
        {
            try
            {
                VacancyCreateModel data = await Task.Run(() => ManageVacancy.Update(model));
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<VacancySkillsCreateModel> UpdateVacancySkill(VacancySkillsCreateModel model)
        //{
        //    try
        //    {
        //        tblVacancieSkill data = await Task.Run(() => ManageVacancySkills.UpdateVacancySkills(model.ConvertTotblVacancySkill()));
        //        return data.ConvertToVacancySkill();

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<VacancyLocationsCreateModel> UpdateVacancyLocation(VacancyLocationsCreateModel model)
        //{
        //    try
        //    {
        //        tblVacancyLocation data = await Task.Run(() => ManageVacancyLocations.UpdateVacancyLocation(model.ConvertTotblVacancyLocation()));
        //        return data.ConvertToVacancyLocation();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<VacancySuppliersCreateModel> UpdateVacancySupplier(VacancySuppliersCreateModel model)
        //{
        //    try
        //    {
        //        tblVacancySupplier data = await Task.Run(() => ManageVacancySuppliers.UpdateVacancySupplier(model.ConvertTotblVacancySupplier()));
        //        return data.ConvertToVacancySupplier();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        public async Task<MSPVacancieTypeCreateModel> UpdateMSPVacancieType(MSPVacancieTypeCreateModel model)
        {
            try
            {
                tblMSPVacancieType data = await Task.Run(() => ManageMSPVacancieType.UpdateMSPVacancieType(model.ConvertTotblMSPVacancieType()));
                return data.ConvertToMSPVacancieType();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public async Task DeleteVacancy(long Id)
        {
            try
            {

                await Task.Run(() => ManageVacancy.DeleteVacancy(Id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteMSPVacancieType(long Id)
        {
            try
            {

                await Task.Run(() => ManageMSPVacancieType.DeleteMSPVacancieType(Id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool dispose)
        {
            if (!IsDisposed)
            {
                if (dispose)
                {
                    this.Dispose();
                }
                IsDisposed = true;
            }
        }

        ~VacanciesManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
