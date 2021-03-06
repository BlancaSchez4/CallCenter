﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Softv.Entities
{
    /// <summary>
    /// Class                   : Softv.Entities.RelEnProcesosEntity.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : RelEnProcesos entity
    /// File                    : RelEnProcesosEntity.cs
    /// Creation date           : 27/04/2016
    /// Creation time           : 05:19 p. m.
    ///</summary>
    [DataContract]
    [Serializable]
    public class RelEnProcesosEntity : BaseEntity
    {
        #region Attributes

        /// <summary>
        /// Property IdProceso
        /// </summary>
        [DataMember]
        public int? IdProceso { get; set; }
        /// <summary>
        /// Property IdPregunta
        /// </summary>
        [DataMember]
        public int? IdPregunta { get; set; }
        /// <summary>
        /// Property Id_ResOpcMult
        /// </summary>
        [DataMember]
        public int? Id_ResOpcMult { get; set; }
        /// <summary>
        /// Property RespAbi
        /// </summary>
        [DataMember]
        public String RespAbi { get; set; }
        /// <summary>
        /// Property RespCerrada
        /// </summary>
        [DataMember]
        public bool? RespCerrada { get; set; }
        [DataMember]
        public PreguntaEntity Pregunta { get; set; }

        [DataMember]
        public ResOpcMultsEntity ResOpcMults { get; set; }

        [DataMember]
        public RelEncuestaClientesEntity RelEncuestaClientes { get; set; }

        #endregion
    }
}

