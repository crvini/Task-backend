
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Task_backend.Core.Entities
{
    public class BaseEntity
    {
        #region Properties
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
      
        #endregion

    }
}
