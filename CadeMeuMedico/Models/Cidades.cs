//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadeMeuMedico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cidades
    {
        public Cidades()
        {
            this.Medicos = new HashSet<Medicos>();
        }
    
        public int IDCidade { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}
