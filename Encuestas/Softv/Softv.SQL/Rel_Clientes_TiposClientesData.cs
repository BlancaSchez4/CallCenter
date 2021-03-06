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
    /// Class                   : Softv.DAO.Rel_Clientes_TiposClientesData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Rel_Clientes_TiposClientes Data Access Object
    /// File                    : Rel_Clientes_TiposClientesDAO.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 05:56 p. m.
    ///</summary>
    public class Rel_Clientes_TiposClientesData : Rel_Clientes_TiposClientesProvider
    {
        /// <summary>
        ///</summary>
        /// <param name="Rel_Clientes_TiposClientes"> Object Rel_Clientes_TiposClientes added to List</param>
        public override int AddRel_Clientes_TiposClientes(Rel_Clientes_TiposClientesEntity entity_Rel_Clientes_TiposClientes)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesAdd", connection);

                AssingParameter(comandoSql, "@CONTRATO", entity_Rel_Clientes_TiposClientes.CONTRATO);

                AssingParameter(comandoSql, "@Clv_TipoCliente", entity_Rel_Clientes_TiposClientes.Clv_TipoCliente);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding Rel_Clientes_TiposClientes " + ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
                result = (int)comandoSql.Parameters["@IdRel_Clientes_TiposClientes"].Value;
            }
            return result;
        }

        /// <summary>
        /// Deletes a Rel_Clientes_TiposClientes
        ///</summary>
        /// <param name="">   to delete </param>
        public override int DeleteRel_Clientes_TiposClientes(long? CONTRATO)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesDelete", connection);

                AssingParameter(comandoSql, "@CONTRATO", CONTRATO);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting Rel_Clientes_TiposClientes " + ex.Message, ex);
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
        /// Edits a Rel_Clientes_TiposClientes
        ///</summary>
        /// <param name="Rel_Clientes_TiposClientes"> Objeto Rel_Clientes_TiposClientes a editar </param>
        public override int EditRel_Clientes_TiposClientes(Rel_Clientes_TiposClientesEntity entity_Rel_Clientes_TiposClientes)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesEdit", connection);

                AssingParameter(comandoSql, "@CONTRATO", entity_Rel_Clientes_TiposClientes.CONTRATO);

                AssingParameter(comandoSql, "@Clv_TipoCliente", entity_Rel_Clientes_TiposClientes.Clv_TipoCliente);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = int.Parse(ExecuteNonQuery(comandoSql).ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating Rel_Clientes_TiposClientes " + ex.Message, ex);
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
        /// Gets all Rel_Clientes_TiposClientes
        ///</summary>
        public override List<Rel_Clientes_TiposClientesEntity> GetRel_Clientes_TiposClientes()
        {
            List<Rel_Clientes_TiposClientesEntity> Rel_Clientes_TiposClientesList = new List<Rel_Clientes_TiposClientesEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGet", connection);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        Rel_Clientes_TiposClientesList.Add(GetRel_Clientes_TiposClientesFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return Rel_Clientes_TiposClientesList;
        }

        /// <summary>
        /// Gets all Rel_Clientes_TiposClientes by List<int>
        ///</summary>
        public override List<Rel_Clientes_TiposClientesEntity> GetRel_Clientes_TiposClientes(List<int> lid)
        {
            List<Rel_Clientes_TiposClientesEntity> Rel_Clientes_TiposClientesList = new List<Rel_Clientes_TiposClientesEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {
                DataTable IdDT = BuildTableID(lid);

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGetByIds", connection);
                AssingParameter(comandoSql, "@IdTable", IdDT);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        Rel_Clientes_TiposClientesList.Add(GetRel_Clientes_TiposClientesFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return Rel_Clientes_TiposClientesList;
        }

        /// <summary>
        /// Gets Rel_Clientes_TiposClientes by
        ///</summary>
        public override Rel_Clientes_TiposClientesEntity GetRel_Clientes_TiposClientesById(long? CONTRATO)
        {
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGetById", connection);
                Rel_Clientes_TiposClientesEntity entity_Rel_Clientes_TiposClientes = null;

                AssingParameter(comandoSql, "@CONTRATO", CONTRATO);


                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
                    if (rd.Read())
                        entity_Rel_Clientes_TiposClientes = GetRel_Clientes_TiposClientesFromReader(rd);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                return entity_Rel_Clientes_TiposClientes;
            }

        }


        public override List<Rel_Clientes_TiposClientesEntity> GetRel_Clientes_TiposClientesByClv_TipoCliente(int? Clv_TipoCliente)
        {
            List<Rel_Clientes_TiposClientesEntity> Rel_Clientes_TiposClientesList = new List<Rel_Clientes_TiposClientesEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGetByClv_TipoCliente", connection);

                AssingParameter(comandoSql, "@Clv_TipoCliente", Clv_TipoCliente);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        Rel_Clientes_TiposClientesList.Add(GetRel_Clientes_TiposClientesFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return Rel_Clientes_TiposClientesList;
        }


        /// <summary>
        ///Get Rel_Clientes_TiposClientes
        ///</summary>
        public override SoftvList<Rel_Clientes_TiposClientesEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<Rel_Clientes_TiposClientesEntity> entities = new SoftvList<Rel_Clientes_TiposClientesEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGetPaged", connection);

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
                        entities.Add(GetRel_Clientes_TiposClientesFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetRel_Clientes_TiposClientesCount();
                return entities ?? new SoftvList<Rel_Clientes_TiposClientesEntity>();
            }
        }

        /// <summary>
        ///Get Rel_Clientes_TiposClientes
        ///</summary>
        public override SoftvList<Rel_Clientes_TiposClientesEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<Rel_Clientes_TiposClientesEntity> entities = new SoftvList<Rel_Clientes_TiposClientesEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGetPagedXml", connection);

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
                        entities.Add(GetRel_Clientes_TiposClientesFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetRel_Clientes_TiposClientesCount(xml);
                return entities ?? new SoftvList<Rel_Clientes_TiposClientesEntity>();
            }
        }

        /// <summary>
        ///Get Count Rel_Clientes_TiposClientes
        ///</summary>
        public int GetRel_Clientes_TiposClientesCount()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGetCount", connection);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
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
        ///Get Count Rel_Clientes_TiposClientes
        ///</summary>
        public int GetRel_Clientes_TiposClientesCount(String xml)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Rel_Clientes_TiposClientes.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_Rel_Clientes_TiposClientesGetCountXml", connection);

                AssingParameter(comandoSql, "@xml", xml);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Rel_Clientes_TiposClientes " + ex.Message, ex);
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
