﻿using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    internal static class ManageCandidateSubmissionSpend
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateSubmissionSpend() { }

        #endregion

        #region Get

        internal static async Task<tblCandidateSubmissionSpend> GetCandidateSubmissionSpends(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateSubmissionSpends
                                                  .Where(x => x.ID == Id).SingleOrDefault());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task InsertCandidateSubmissionSpend(tblCandidateSubmissionSpend model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var response = db.tblCandidateSubmissionSpends.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Update

        internal static async Task<tblCandidateSubmissionSpend> UpdateCandidateSubmissionSpend(tblCandidateSubmissionSpend model)
        {
            try
            {
                using (db = new eMSPEntities())
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
        internal static async Task DeleteCandidateSubmissionSpend(long PlacementID)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblCandidateSubmissionSpend> obj = db.tblCandidateSubmissionSpends
                                                                        .Where(cs => cs.PlacementID == PlacementID)
                                                                        .ToList();
                    db.tblCandidateSubmissionSpends.RemoveRange(obj);
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