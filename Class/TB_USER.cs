using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Class
{
    public class TB_USER
    {
        private Guid Id;
        private string Fullname;
        private string Email;
        private string PasswordHash;
        private int Role;

        [Key]
         public Guid ID
        {
            get { return Id; }
            set { Id = value; }
        }
        [StringLength(200)]
        [Required]
        public string FULLNAME
        {
            get { return Fullname; }
            set { Fullname = value; }
        }
        [StringLength(100)]

        public string EMAIL
        {
            get { return Email; }
            set { Email = value; }
        }
        [Required]
        public string PASSWORDHASH
        {
            get { return PasswordHash; }
            set { PasswordHash = value; }
        }
        public int ROLE
        {
            get { return Role; }
            set { Role = value; }
        }
        // Constructor
        public TB_USER()
        {
            Fullname = "";
            Email = "";
            PasswordHash = "";
            Role = 0;
        }
    }
}
