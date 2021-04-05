//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace bysj.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    
    public partial class Machine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Machine()
        {
            this.Event = new HashSet<Event>();
        }
    
        public int id { get; set; }
        public string type { get; set; }
        public int area_id { get; set; }
        public string address { get; set; }
        public Nullable<double> alarm_temperature { get; set; }
        public Nullable<System.DateTime> last_time { get; set; }
        public Nullable<double> last_temperature { get; set; }
        public Nullable<int> count { get; set; }
        public Nullable<System.DateTime> update_time { get; set; }
        public string report { get; set; }
        public string situation { get; set; }
    
        public virtual Area Area { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }
    }
}
