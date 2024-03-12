namespace WebCommerce.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            this.IsActive = true;
        }
        public bool IsActive { get; set; }
    }
}
