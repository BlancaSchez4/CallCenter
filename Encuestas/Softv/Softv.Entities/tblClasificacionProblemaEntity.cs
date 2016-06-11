﻿
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    namespace Softv.Entities
    {
    /// <summary>
    /// Class                   : Softv.Entities.tblClasificacionProblemaEntity.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : tblClasificacionProblema entity
    /// File                    : tblClasificacionProblemaEntity.cs
    /// Creation date           : 08/06/2016
    /// Creation time           : 10:52 a. m.
    ///</summary>
    [DataContract]
    [Serializable]
    public class tblClasificacionProblemaEntity : BaseEntity
    {
    #region Attributes
    
      /// <summary>
      /// Property clvProblema
      /// </summary>
      [DataMember]
      public long? clvProblema { get; set; }
      /// <summary>
      /// Property descripcion
      /// </summary>
      [DataMember]
      public String descripcion { get; set; }
      /// <summary>
      /// Property activo
      /// </summary>
      [DataMember]
      public bool? activo { get; set; }
    #endregion
    }
    }

  