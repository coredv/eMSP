﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eMSP.Data.DataServices.JobVacancies;
using eMSP.ViewModel.JobVacancies;
using System.Web.Http.Description;
using System.Threading.Tasks;
using eMSP.ViewModel.MSP;
using Microsoft.AspNet.Identity;
using eMSP.WebAPI.Controllers.Helpers;

namespace eMSP.WebAPI.Controllers.JobVacancies
{
    [RoutePrefix("api/JobVacancie")]
    [Authorize(Roles = ApplicationRoles.VacancyFull)]
    [Queryable]
    [AllowAnonymous]
    public class JobVacanciesController : ApiController
    {
        #region Intialisation

        private VacanciesManager VacanciesService;
        string userId;

        public JobVacanciesController()
        {
            VacanciesService = new VacanciesManager();
        }

        #endregion

        #region Get

        [Route("getVacancy")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.VacancyView+","+ ApplicationRoles.VacancyCreate)]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> GetVacancy(long id)
        {
            try
            {

                return Ok(await VacanciesService.GetVacancy(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getAllVacancy")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.VacancyView + "," + ApplicationRoles.VacancyCreate)]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> GetAllVacancy(CompanyModel model)
        {
            try
            {
                return Ok(await VacanciesService.GetAllVacancies(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getVacancyComments")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.VacancyView + "," + ApplicationRoles.VacancyCreate)]
        public async Task<IHttpActionResult> GetVacancyComments(long id)
        {
            try
            {
                return Ok(await VacanciesService.GetVacancyComments(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getMSPVacancyType")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.VacancyTypeView + "," + ApplicationRoles.VacancyTypeCreate)]
        public async Task<IHttpActionResult> GetMSPVacancyType(MSPVacancieTypeCreateModel data)
        {
            try
            {
                return Ok((await VacanciesService.GetMSPVacancieType(data)).AsQueryable());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getVacancyStatus")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.VacancyView + "," + ApplicationRoles.VacancyCreate)]
        public async Task<IHttpActionResult> GetVacancyStatus()
        {
            try
            {
                return Ok((await VacanciesService.GetVacancyStatus()).AsQueryable());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insert

        [Route("createVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        [Authorize(Roles = ApplicationRoles.VacancyCreate)]
        public async Task<IHttpActionResult> InsertVacancy(VacancyCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model.Vacancy, "create", userId);

                return Ok(await VacanciesService.CreateVacancy(model));
            }
            catch (Exception ex)
            {
                return Ok(ex.StackTrace);
            }
        }

        [Route("commentVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCommentCreateModel))]
        [Authorize(Roles = ApplicationRoles.VacancyView + "," + ApplicationRoles.VacancyCreate)]
        public async Task<IHttpActionResult> CommentVacancy(VacancyCommentCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model.comment, "create", userId);
                Helpers.Helpers.AddBaseProperties(model.vacancyComment, "create", userId);
                Helpers.Helpers.AddBaseProperties(model.commentUser, "create", userId);
                model.commentUser.userId = userId;

                return Ok(await VacanciesService.CommentVacancy(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("createMSPVacancieType")]
        [HttpPost]
        [ResponseType(typeof(MSPVacancieTypeCreateModel))]
        [Authorize(Roles = ApplicationRoles.VacancyTypeCreate)]
        public async Task<IHttpActionResult> InsertMSPVacancieType(MSPVacancieTypeCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId);

                return Ok(await VacanciesService.CreateMSPVacancieType(model));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region update

        [Route("updateVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> UpdateVacancy(VacancyCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model.Vacancy, "update", userId);
                
                return Ok(await VacanciesService.UpdateVacancy(model));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("updateMSPVacancieType")]
        [HttpPost]
        [ResponseType(typeof(MSPVacancieTypeCreateModel))]
        public async Task<IHttpActionResult> UpdateMSPVacancieType(MSPVacancieTypeCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);

                return Ok(await VacanciesService.UpdateMSPVacancieType(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        [Route("deleteVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> DeleteVacancy(long model)
        {
            try
            {
                await VacanciesService.DeleteVacancy(model);
                return Ok("Success");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("deleteMSPVacancieType")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> DeleteMSPVacancieType(MSPVacancieTypeCreateModel data)
        {
            try
            {
                await VacanciesService.DeleteMSPVacancieType(data.id);
                return Ok("Success");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
