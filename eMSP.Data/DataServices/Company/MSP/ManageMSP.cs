﻿using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace eMSP.Data.DataServices.Company
{
    internal static class ManageMSP
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageMSP()
        {
           
        }

        #endregion

        #region Get
        internal static async Task<tblMSPDetail> GetMSPDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    long id = Convert.ToInt64(ConfigurationManager.AppSettings["MSP_ID"]);
                    Id= id != null ? id : Id ;
                    return await Task.Run(() => db.tblMSPDetails.Where(x => x.ID == Id).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblMSPDetail>> GetAllMSPDetails(CompanySearchModel model)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPDetails.Where(x => x.CompanyName == model.companyName).ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblMSPDetail> InsertMSP(tblMSPDetail model)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    model = db.tblMSPDetails.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Update

        internal static async Task<tblMSPDetail> UpdateMSP(tblMSPDetail model)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Delete

        internal static async Task DeleteMSP(long Id)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    tblMSPDetail obj = await db.tblMSPDetails.FindAsync(Id);
                    db.tblMSPDetails.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        #endregion


    }
}
