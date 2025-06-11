using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Class
{
    public class TB_PROPERTY
    {
        private Guid Id;
        private string Name;
        private string Location;
        private decimal Price;
        private bool IsAvailable;


        [Key]
        public Guid ID
        {
            get { return Id; }
            set { Id = value; }
        }
        [Required]
        public string NAME
        {
            get { return Name; }
            set { Name = value; }
        }
        [Required]
        public string LOCATION
        {
            get { return Location; }
            set { Location = value; }
        }
        [Required]
        [Range(0, 9999999.99, ErrorMessage = "Price must be a number between 0 and 9,999,999.99")]
        public decimal PRICE
        {
            get { return Price; }
            set { Price = value; }
        }
        public bool ISAVILABLE
        {
            get { return IsAvailable; }
            set { IsAvailable = value; }
        }

        // Constructor
        public TB_PROPERTY()
        {
            Name = "";
            Location = "";
            Price = 0;
            IsAvailable = false;
        }
    }
}
