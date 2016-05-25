﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Softv.Entities;
using Softv.Providers;
using SoftvConfiguration;
using Globals;

namespace Softv.DAO
{
    /// <summary>
    /// Class                   : Softv.DAO.CIUDADData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : CIUDAD Data Access Object
    /// File                    : CIUDADDAO.cs
    /// Creation date           : 20/05/2016
    /// Creation time           : 06:40 p. m.
    ///</summary>
    public class CIUDADData : CIUDADProvider
    {
        /// <summary>
        ///</summary>
        /// <param name="CIUDAD"> Object CIUDAD added to List</param>
        public override int AddCIUDAD(CIUDADEntity entity_CIUDAD)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADAdd", connection);

                AssingParameter(comandoSql, "@Clv_Ciudad", null, pd: ParameterDirection.Output, IsKey: true);

                AssingParameter(comandoSql, "@Nombre", entity_CIUDAD.Nombre);

                AssingParameter(comandoSql, "@CobroEspecial", entity_CIUDAD.CobroEspecial);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
                result = (int)comandoSql.Parameters["@Clv_Ciudad"].Value;
            }
            return result;
        }

        /// <summary>
        /// Deletes a CIUDAD
        ///</summary>
        /// <param name="">  Clv_Ciudad to delete </param>
        public override int DeleteCIUDAD(int? Clv_Ciudad)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADDelete", connection);

                AssingParameter(comandoSql, "@Clv_Ciudad", Clv_Ciudad);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Edits a CIUDAD
        ///</summary>
        /// <param name="CIUDAD"> Objeto CIUDAD a editar </param>
        public override int EditCIUDAD(CIUDADEntity entity_CIUDAD)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADEdit", connection);

                AssingParameter(comandoSql, "@Clv_Ciudad", entity_CIUDAD.Clv_Ciudad);

                AssingParameter(comandoSql, "@Nombre", entity_CIUDAD.Nombre);

                AssingParameter(comandoSql, "@CobroEspecial", entity_CIUDAD.CobroEspecial);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = int.Parse(ExecuteNonQuery(comandoSql).ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all CIUDAD
        ///</summary>
        public override List<CIUDADEntity> GetCIUDAD()
        {
            List<CIUDADEntity> CIUDADList = new List<CIUDADEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGet", connection);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        CIUDADList.Add(GetCIUDADFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return CIUDADList;
        }

        /// <summary>
        /// Gets all CIUDAD by List<int>
        ///</summary>
        public override List<CIUDADEntity> GetCIUDAD(List<int> lid)
        {
            List<CIUDADEntity> CIUDADList = new List<CIUDADEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {
                DataTable IdDT = BuildTableID(lid);

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGetByIds", connection);
                AssingParameter(comandoSql, "@IdTable", IdDT);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        CIUDADList.Add(GetCIUDADFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return CIUDADList;
        }

        /// <summary>
        /// Gets CIUDAD by
        ///</summary>
        public override CIUDADEntity GetCIUDADById(int? Clv_Ciudad)
        {
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGetById", connection);
                CIUDADEntity entity_CIUDAD = null;


                AssingParameter(comandoSql, "@Clv_Ciudad", Clv_Ciudad);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
                    if (rd.Read())
                        entity_CIUDAD = GetCIUDADFromReader(rd);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                return entity_CIUDAD;
            }

        }


        public override List<CIUDADEntity> GetCIUDADByClv_Ciudad(int? Clv_Ciudad)
        {
            List<CIUDADEntity> CIUDADList = new List<CIUDADEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGetByClv_Ciudad", connection);

                AssingParameter(comandoSql, "@Clv_Ciudad", Clv_Ciudad);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        CIUDADList.Add(GetCIUDADFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return CIUDADList;
        }


        /// <summary>
        ///Get CIUDAD
        ///</summary>
        public override SoftvList<CIUDADEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<CIUDADEntity> entities = new SoftvList<CIUDADEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGetPaged", connection);

                AssingParameter(comandoSql, "@pageIndex", pageIndex);
                AssingParameter(comandoSql, "@pageSize", pageSize);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);
                    while (rd.Read())
                    {
                        entities.Add(GetCIUDADFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetCIUDADCount();
                return entities ?? new SoftvList<CIUDADEntity>();
            }
        }

        /// <summary>
        ///Get CIUDAD
        ///</summary>
        public override SoftvList<CIUDADEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<CIUDADEntity> entities = new SoftvList<CIUDADEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGetPagedXml", connection);

                AssingParameter(comandoSql, "@pageSize", pageSize);
                AssingParameter(comandoSql, "@pageIndex", pageIndex);
                AssingParameter(comandoSql, "@xml", xml);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);
                    while (rd.Read())
                    {
                        entities.Add(GetCIUDADFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetCIUDADCount(xml);
                return entities ?? new SoftvList<CIUDADEntity>();
            }
        }

        /// <summary>
        ///Get Count CIUDAD
        ///</summary>
        public int GetCIUDADCount()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGetCount", connection);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }


        /// <summary>
        ///Get Count CIUDAD
        ///</summary>
        public int GetCIUDADCount(String xml)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CIUDAD.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CIUDADGetCountXml", connection);

                AssingParameter(comandoSql, "@xml", xml);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CIUDAD " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        #region Customs Methods

        #endregion
    }
}
